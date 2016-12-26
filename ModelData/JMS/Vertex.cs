using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.Generic;

namespace ModelTools.ModelData.JMS
{
  public class Vertex
  {
    public RealPoint3D Location;
    public RealNormal Normal;
    public double Unk1;
    public double Unk2;
    public double Unk3;
    public VertexWeightData WeightData;

    public string[] ToJMS()
    {
      return new string[]
      {
        WeightData.Node0Index.ToString(),
        Location.ToJMS()[0],
        Normal.ToJMS()[0],
        WeightData.Node1Index.ToString(),
        WeightData.Node1Weight.ToString("0.000000"),
        //0.ToString("0.000000"),
        Unk1.ToString("0.000000"),
        Unk2.ToString("0.000000"),
        Unk3.ToString("0.000000"),
        //WeightData.Node0Weight.ToString("0.0000")
      };
    }

    public Vertex(ref int index, string[] file)
    {
      int node0Index;
      int node1Index;
      double node1Weight;

      try
      {
        node0Index = Convert.ToInt32(file[index]); index++;
        Location = new RealPoint3D(ref index, file);
        Normal = new RealNormal(ref index, file);
        node1Index = Convert.ToInt32(file[index]); index++;
        node1Weight = Convert.ToDouble(file[index]); index++;
        Unk1 = Convert.ToDouble(file[index]); index++;
        Unk2 = Convert.ToDouble(file[index]); index++;
        Unk3 = Convert.ToDouble(file[index]); index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid triangle at line " + index);
        return;
      }

      WeightData = new VertexWeightData(node0Index, /*node0Weight, */node1Index, node1Weight);
    }
  }
}