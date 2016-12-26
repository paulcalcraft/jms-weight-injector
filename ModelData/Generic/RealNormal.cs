using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.JMS;

namespace ModelTools.ModelData.Generic
{
  public class RealNormal
  {
    public double I;
    public double J;
    public double K;

    public string[] ToJMS()
    {
      return new string[]
      {
        I.ToString("0.000000")+'\t'+
        J.ToString("0.000000")+'\t'+
        K.ToString("0.000000")
      };
    }

    public RealNormal(ref int index, string[] file)
    {
      try
      {
        string[] parts = file[index].Split('\t');
        I = Convert.ToDouble(parts[0]);
        J = Convert.ToDouble(parts[1]);
        K = Convert.ToDouble(parts[2]);
        index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid vertex normal at line " + index);
      }
    }
  }
}