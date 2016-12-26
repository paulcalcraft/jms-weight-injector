using System;
using System.Collections.Generic;
using System.Text;
using ModelTools.ModelData.Generic;
using System.Windows.Forms;

namespace ModelTools.ModelData.VWI
{
  public class VWIFile
  {
    public Node[] Nodes;
    public Vertex[] Vertices;

    public int VerticesWithExcessBones = 0;

    public void ReadFromVWI(string[] file)
    {
      int index = 0;

      // Nodes
      int nodeCount = Convert.ToInt32(file[index]); index++;
      Nodes = new Node[nodeCount];
      for (int i = 0; i < nodeCount; i++)
      {
        Nodes[i] = new Node(ref index, file);
      }

      // Vertices
      int vertexCount = Convert.ToInt32(file[index]); index++;
      Vertices = new Vertex[vertexCount];
      for (int i = 0; i < vertexCount; i++)
      {
        Vertices[i] = new Vertex(ref index, file, Nodes);
        if (Vertices[i].NodeWeights.Count > 2)
          VerticesWithExcessBones++;
      }    
    }

    public Dictionary<RealPoint3D, Vertex> UniqueVertices;

    public void Optimise()
    {
      UniqueVertices = new Dictionary<RealPoint3D, Vertex>();

      for (int i = 0; i < Vertices.Length; i++)
      {
        if (!UniqueVertices.ContainsKey(Vertices[i].Location))
        {
          UniqueVertices.Add(Vertices[i].Location, Vertices[i]);
        }
      }
    }
  }
}
