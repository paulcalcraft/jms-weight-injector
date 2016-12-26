using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.JMS;

namespace ModelTools.ModelData.Generic
{
  public class RealQuaternion
  {
    public double I;
    public double J;
    public double K;
    public double W;

    public string[] ToJMS()
    {
      return new string[]
      {
        I.ToString("0.000000")+'\t'+
        J.ToString("0.000000")+'\t'+
        K.ToString("0.000000")+'\t'+
        W.ToString("0.000000")
      };
    }

    public RealQuaternion(ref int index, string[] file)
    {
      try
      {
        string[] parts = file[index].Split('\t');
        I = Convert.ToDouble(parts[0]);
        J = Convert.ToDouble(parts[1]);
        K = Convert.ToDouble(parts[2]);
        W = Convert.ToDouble(parts[3]);
        index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid quaternion at line " + index);
      }
    }
  }
}