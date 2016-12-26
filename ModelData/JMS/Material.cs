using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ModelTools.ModelData.JMS
{
  public class Material
  {
    public string Name;
    public string Path;

    public string[] ToJMS()
    {
      return new string[]
      {
        Name,
        Path
      };
    }

    public Material(ref int index, string[] file)
    {
      try
      {
        Name = file[index]; index++;
        Path = file[index]; index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid material at line " + index);
      }
    }
  }
}