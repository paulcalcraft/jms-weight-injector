using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ModelTools.ModelData.JMS;

namespace ModelTools.ModelData.Generic
{
  public class RealPoint3D
  {
    public double X;
    public double Y;
    public double Z;

    public string[] ToJMS()
    {
      return new string[]
      {
        X.ToString("0.000000")+'\t'+
        Y.ToString("0.000000")+'\t'+
        Z.ToString("0.000000")
      };
    }

    public static int GetIntegerSignificance(double value)
    {
      int i = 0;
      while (Math.Abs(value) > Math.Pow(10, i))
        i++;
      return i;
    }

    public static double RoundToFigurePrecision(double value)
    {
      int i = GetIntegerSignificance(value);
      int round = Globals.FigurePrecision - i;
      if (round < 0)
        round = 0;
      return Math.Round(value, round);
    }

    public static double RoundToFigurePrecision(double value, int integerSignificance)
    {
      int round = Globals.FigurePrecision - integerSignificance;
      if (round < 0)
        round = 0;
      return Math.Round(value, round);
    }

    public static double RoundToFigures(double value, int figures)
    {
      int i = GetIntegerSignificance(value);
      int round = figures - i;
      if (round < 0)
        round = 0;
      return Math.Round(value, round);
    }

    public static bool CompareValues(double value1, double value2)
    {
      int i = GetIntegerSignificance(value1);

      value1 = RoundToFigurePrecision(value1, i);
      value2 = RoundToFigurePrecision(value2, i);

      double range = Globals.RangePrecision * Math.Pow(10, -(Globals.FigurePrecision - i));

      return value1 + range >= value2 && value1 - range <= value2;
    }

    public static bool Compare(RealPoint3D point1, RealPoint3D point2)
    {
      bool validX = CompareValues(point1.X, point2.X);
      bool validY = CompareValues(point1.Y, point2.Y);
      bool validZ = CompareValues(point1.Z, point2.Z);
      return validX && validY && validZ;
    }

    public RealPoint3D(double x, double y, double z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public RealPoint3D(ref int index, string[] file)
    {
      try
      {
        string[] parts = file[index].Split('\t');
        X = Convert.ToDouble(parts[0]);
        Y = Convert.ToDouble(parts[1]);
        Z = Convert.ToDouble(parts[2]);
        index++;
      }
      catch
      {
        Output.WriteLine("Error: Invalid vertex co-ordinate point at line " + index);
      }
    }

    #region Overloaded Operators
    public static bool operator ==(RealPoint3D point1, RealPoint3D point2)
    {
      if (point1 == null && point2 == null) return true;
      if (point1 == null) return false;
      if (point2 == null) return false;
      //return o1.X == o2.X && o1.Y == o2.Y && o1.Z == o2.Z;
      /*double baseRange = 1;

      bool validX = WithinRange(o1.X, o2.X, ModelData.PointPrecision, baseRange);
      bool validY = WithinRange(o1.Y, o2.Y, ModelData.PointPrecision, baseRange);
      bool validZ = WithinRange(o1.Z, o2.Z, ModelData.PointPrecision, baseRange);

      return validX && validY && validZ;*/
      return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
    }

    public static bool operator !=(RealPoint3D point1, RealPoint3D point2)
    {
      return !(point1 == point2);
    }
    #endregion

    #region Object Overidden Methods
    public override bool Equals(object obj)
    {
      RealPoint3D point = obj as RealPoint3D;
      return RealPoint3D.Compare(this, point);
    }

    public string GetHashString()
    {
      return string.Format("{0" + Globals.HashCodeFormat + "}{1" + Globals.HashCodeFormat + "}{2" + Globals.HashCodeFormat + "}", RoundToFigures(X, Globals.HashCodePrecision), RoundToFigures(Y, Globals.HashCodePrecision), RoundToFigures(Z, Globals.HashCodePrecision));
    }

    public override int GetHashCode()
    {
      int hash = GetHashString().GetHashCode();
      return hash;
    }

    public override string ToString()
    {
      return string.Format("{0}\t{1}\t{2}", X, Y, Z);
    }
    #endregion
  }
}