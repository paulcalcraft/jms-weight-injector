using System;
using System.Collections.Generic;
using System.Text;
using ModelTools.ModelData.Generic;

namespace ModelTools.ModelData.VWI
{
  public class Vertex
  {
    public RealPoint3D Location;
    public Dictionary<Node, double> NodeWeights;

    public Vertex(ref int index, string[] file, Node[] nodes)
    {
      NodeWeights = new Dictionary<Node, double>();

      string[] parts = file[index].Split('\t'); index++;
      if (parts.Length % 2 != 0)
      {
        Output.WriteLine("Error: Invalid node weight data at line " + index);
      }
      for (int i = 0; i < parts.Length; i += 2)
      {
        int nodeIndex = Convert.ToInt32(parts[i]) - 1;
        double nodeWeight = Convert.ToDouble(parts[i+1]);
        NodeWeights.Add(nodes[nodeIndex], nodeWeight);
      }

      parts = file[index].Trim('[', ']').Split(','); index++;
      double x = Convert.ToDouble(parts[0]);
      double y = Convert.ToDouble(parts[1]);
      double z = Convert.ToDouble(parts[2]);
      Location = new RealPoint3D(x, y, z);
    }
  }
}
