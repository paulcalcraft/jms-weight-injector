using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.Generic;

namespace ModelTools.ModelData.JMS
{
  public class Node
  {
    public int Index;
    public string Name;
    public int FirstChildNodeIndex;
    public int NextSiblingNodeIndex;
    public RealQuaternion Rotation;
    public RealPoint3D Translation;

    public string[] ToJMS()
    {
      return new string[]
      {
        Name,
        FirstChildNodeIndex.ToString(),
        NextSiblingNodeIndex.ToString(),
        Rotation.ToJMS()[0],
        Translation.ToJMS()[0]
      };
    }

    public Node(ref int index, string[] file, int nodeIndex)
    {
      try
      {
        Index = nodeIndex;
        Name = file[index]; index++;
        FirstChildNodeIndex = Convert.ToInt32(file[index]); index++;
        NextSiblingNodeIndex = Convert.ToInt32(file[index]); index++;
        string[] parts = file[index].Split('\t');
        Rotation = new RealQuaternion(ref index, file);
        Translation = new RealPoint3D(ref index, file);
      }
      catch
      {
        Output.WriteLine("Error: Invalid node at line " + index);
      }
    }

    public override int GetHashCode()
    {
      return Name.ToLower().GetHashCode();
    }
  }
}