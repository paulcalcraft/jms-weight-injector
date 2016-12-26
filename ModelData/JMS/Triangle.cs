using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ModelTools.ModelData.JMS
{
  public class Triangle
  {
    public int RegionIndex;
    public int ShaderIndex;
    public int Vertex0Index;
    public int Vertex1Index;
    public int Vertex2Index;

    public string[] ToJMS()
    {
      return new string[]
      {
        RegionIndex.ToString(),
        ShaderIndex.ToString(),
        Vertex0Index.ToString()+'\t'+
        Vertex1Index.ToString()+'\t'+
        Vertex2Index.ToString()
      };
    }

    public Triangle(ref int index, string[] file)
    {
      try
      {
        RegionIndex = Convert.ToInt32(file[index]); index++;
        ShaderIndex = Convert.ToInt32(file[index]); index++;
        string[] parts = file[index].Split('\t');
        Vertex0Index = Convert.ToInt32(parts[0]);
        Vertex1Index = Convert.ToInt32(parts[1]);
        Vertex2Index = Convert.ToInt32(parts[2]);
        index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid triangle at line " + index);
      }
    }
  }
}