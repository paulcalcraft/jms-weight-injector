using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.Generic;

namespace ModelTools.ModelData.JMS
{
  public class Region
  {
    public string Name;

    public Region(ref int index, string[] file)
    {
      Name = file[index]; index++;
    }
  }
}