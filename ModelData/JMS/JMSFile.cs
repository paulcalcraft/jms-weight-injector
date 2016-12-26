using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using ModelTools.ModelData.Generic;

namespace ModelTools.ModelData.JMS
{  
  public class JMSFile
  {
    public static string InjectorVersion = "v1.0.2";

    public int Version;
    public long NodeChecksum;
    public Node[] Nodes;
    public Material[] Materials;
    public Marker[] Markers;
    public Region[] Regions;
    public Vertex[] Vertices;
    public Triangle[] Triangles;

    public Dictionary<string, Node> NodeLookup;

    public void ReadFromJMS(string[] file)
    {
      int index = 0;
      NodeLookup = new Dictionary<string, Node>();

      try
      {
        Version = Convert.ToInt32(file[index]); index++;
        NodeChecksum = Convert.ToInt64(file[index]); index++;
      }
      catch
      {
          Output.WriteLine("Error: Invalid meta data at line " + index);
      }
      // Nodes
      int nodeCount = Convert.ToInt32(file[index]); index++;
      Nodes = new Node[nodeCount];
      for (int i = 0; i < nodeCount; i++)
      {
        Nodes[i] = new Node(ref index, file, i);
        NodeLookup.Add(Nodes[i].Name.ToLower(), Nodes[i]);
      }

      // Materials
      int materialCount = Convert.ToInt32(file[index]); index++;
      Materials = new Material[materialCount];
      for (int i = 0; i < materialCount; i++)
      {
        Materials[i] = new Material(ref index, file);
      }

      // Markers
      int markerCount = Convert.ToInt32(file[index]); index++;
      Markers = new Marker[markerCount];
      for (int i = 0; i < markerCount; i++)
      {
        Markers[i] = new Marker(ref index, file);
      }

      // Regions
      int regionCount = Convert.ToInt32(file[index]); index++;
      Regions = new Region[regionCount];
      for (int i = 0; i < regionCount; i++)
      {
        Regions[i] = new Region(ref index, file);
      }

      // Vertices
      int vertexCount = Convert.ToInt32(file[index]); index++;
      Vertices = new Vertex[vertexCount];
      for (int i = 0; i < vertexCount; i++)
      {
        Vertices[i] = new Vertex(ref index, file);
      }

      // Triangles
      int triangleCount = Convert.ToInt32(file[index]); index++;
      Triangles = new Triangle[triangleCount];
      for (int i = 0; i < triangleCount; i++)
      {
        Triangles[i] = new Triangle(ref index, file);
      }
    }

    public VWI.Vertex FullSearch(RealPoint3D needle, IDictionary<RealPoint3D, VWI.Vertex> haystack)
    {
      foreach (VWI.Vertex v in haystack.Values)
      {
        if (v.Location.Equals(needle))
          return v;
      }
      return null;
    }

    public int ImportWeights(VWI.VWIFile vwi, List<Vertex> vertexReference, out List<Vertex> unmatchedVertices)
    {
      int matched = 0;
      unmatchedVertices = new List<Vertex>();

      ICollection<Vertex> jmsVerts;

      if (vertexReference != null)
        jmsVerts = vertexReference;
      else
        jmsVerts = UniqueVertices.Values;

      foreach (Vertex vertex in jmsVerts)
      {
        VWI.Vertex foundVert = null;

        if (Globals.PerformHash)
        {
          if (vwi.UniqueVertices.ContainsKey(vertex.Location))
          {
            foundVert = vwi.UniqueVertices[vertex.Location];
          }
        }
        else
        {
          foundVert = FullSearch(vertex.Location, vwi.UniqueVertices);
        }

        if (foundVert != null)
        {
          int node0Index = 0;
          int node1Index = -1;
          double node1Weight = 0;

          if (foundVert.Location.X == -0.659887D)
          {
            string lol = "ok";
            lol += "k";
          }

          VWI.Vertex wVert = foundVert;

          int i = 0;
          foreach (KeyValuePair<VWI.Node, double> nodeWeight in wVert.NodeWeights)
          {
            if (i > 1)
              break;
            if (i == 0)
            {
              node0Index = NodeLookup[nodeWeight.Key.Name.ToLower()].Index;
              node1Weight = 1D - nodeWeight.Value;
            }
            else
            {
              node1Index = NodeLookup[nodeWeight.Key.Name.ToLower()].Index;
            }
            
            i++;
          }
          
          if (wVert.NodeWeights.Count == 0)
          {
            node0Index = 0;
            node1Weight = 0;
          }

          VertexWeightData vwd = new VertexWeightData(node0Index, node1Index, node1Weight);
          vwd.Round();

          vertex.WeightData.CopyFrom(vwd);
          matched++;
          if (Globals.DirectMap)
            vwi.UniqueVertices.Remove(wVert.Location);
        }
        else
        {
          unmatchedVertices.Add(vertex);
        }
      }

      return matched;
    }

    public string[] WriteToJMS()
    {
      List<string> file = new List<string>();

      file.Add(Version.ToString());
      file.Add(NodeChecksum.ToString());

      // Nodes
      file.Add(Nodes.Length.ToString());
      foreach (Node o in Nodes)
      {
        string[] temp = o.ToJMS();
        foreach (string s in temp)
        {
          file.Add(s);
        }
      }

      // Materials
      file.Add(Materials.Length.ToString());
      foreach (Material o in Materials)
      {
        string[] temp = o.ToJMS();
        foreach (string s in temp)
        {
          file.Add(s);
        }
      }

      // Markers
      file.Add(Markers.Length.ToString());
      foreach (Marker o in Markers)
      {
        string[] temp = o.ToJMS();
        foreach (string s in temp)
        {
          file.Add(s);
        }
      }

      // Regions
      file.Add(Regions.Length.ToString());
      foreach (Region o in Regions)
      {
        file.Add(o.Name);
      }

      // Vertices
      file.Add(Vertices.Length.ToString());
      foreach (Vertex v in Vertices)
      {
        string[] temp = v.ToJMS();
        foreach (string s in temp)
        {
          file.Add(s);
        }
      }

      // Triangles
      file.Add(Triangles.Length.ToString());
      foreach (Triangle t in Triangles)
      {
        string[] temp = t.ToJMS();
        foreach (string s in temp)
        {
          file.Add(s);
        }
      }

      file.Add("");
      file.Add("Weight data injected by JMSWeightInjector "+InjectorVersion+" at "+DateTime.Now.ToShortTimeString()+" on "+DateTime.Now.ToLongDateString());

      return file.ToArray();
    }

    public Dictionary<RealPoint3D, Vertex> UniqueVertices;

    public void Optimise()
    {
      //UniqueVertices = new List<Vertex>();
      UniqueVertices = new Dictionary<RealPoint3D, Vertex>();

      for (int i = 0; i < Vertices.Length; i++)
      {
        Vertex v = Vertices[i];
        Vertex f = null;

        if (Globals.PerformHash)
        {
          if (UniqueVertices.ContainsKey(v.Location))
            f = UniqueVertices[v.Location];
        }
        else
        {
          foreach (Vertex s in UniqueVertices.Values)
          {
            if (v.Location.Equals(s.Location))
            {
              f = s;
              break;
            }
          }
        }

        if (f != null)
        {
          v.WeightData = f.WeightData;
        }
        else
        {
          UniqueVertices.Add(v.Location, v);
        }
      }

      /*
      Vertex[] verts = r.Vertices;
      for (int i = 0; i < verts.Length; i++)
      {
        if (Globals.PerformHash)
        {
          if (UniqueVertices.ContainsKey(verts[i].Location))
          {
            verts[i].WeightData = UniqueVertices[verts[i].Location].WeightData;
          }
          else
          {
            UniqueVertices.Add(verts[i].Location, verts[i]);
          }
        }
      }
      */
    }
  }
}