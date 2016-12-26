using System;
using System.Collections.Generic;
using System.Text;

namespace ModelTools.ModelData.VWI
{
  public class Node
  {
    public string Name;

    public Node(ref int index, string[] file)
    {
      Name = file[index]; index++;
    }

    public override int GetHashCode()
    {
      return Name.ToLower().GetHashCode();
    }
  }
}
