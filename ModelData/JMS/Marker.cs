using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.Generic;

namespace ModelTools.ModelData.JMS
{
  public class Marker
  {
    public string Name;
    public int Unk1 = -1;
    public int ParentNodeIndex;
    public RealQuaternion Rotation;
    public RealPoint3D Translation;
    public double Unk2;

    public string[] ToJMS()
    {
      return new string[]
      {
        Name,
        Unk1.ToString(),
        ParentNodeIndex.ToString(),
        Rotation.ToJMS()[0],
        Translation.ToJMS()[0],
        Unk2.ToString("0.000000")
      };
    }

    public Marker(ref int index, string[] file)
    {
      try
      {
        Name = file[index]; index++;
        Unk1 = Convert.ToInt32(file[index]); index++;
        ParentNodeIndex = Convert.ToInt32(file[index]); index++;
        Rotation = new RealQuaternion(ref index, file);
        Translation = new RealPoint3D(ref index, file);
        Unk2 = Convert.ToDouble(file[index]); index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid marker at line " + index);
      }
    }
  }
}