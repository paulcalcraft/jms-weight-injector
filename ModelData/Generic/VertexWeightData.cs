using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ModelTools.ModelData.Generic
{
  public class VertexWeightData
  {
    public int Node0Index;
    public double Node0Weight
    {
      get { return 1D - Node1Weight; }
    }
    public int Node1Index;
    public double Node1Weight;

    public VertexWeightData(int node0Index, /*double node0Weight, */int node1Index, double node1Weight)
    {
      this.Node0Index = node0Index;
      /*this.Node0Weight = node0Weight;*/
      this.Node1Index = node1Index;
      this.Node1Weight = node1Weight;
    }

    public void CopyFrom(VertexWeightData vwd)
    {
      this.Node0Index = vwd.Node0Index;
      /*this.Node0Weight = vwd.Node0Weight;*/
      this.Node1Index = vwd.Node1Index;
      this.Node1Weight = vwd.Node1Weight;
    }

    public void Round()
    {
      /*if (Node1Index == -1)
      {
        Node1Weight = 0D;
        return true;
      }
      */
      int precision = 6;

      //Node0Weight = Math.Round(Node0Weight, precision);
      Node1Weight = Math.Round(Node1Weight, precision);

      if (Node1Index == -1)
        Node1Weight = 0;

      if (Node0Weight <= 0)
      {
        Node0Index = Node1Index;
        Node1Index = -1;
        Node1Weight = 0;
      }
      /*

      double totalWeight = Node0Weight + Node1Weight;
      if (totalWeight == 1D)
        return false; // Already normalised*/

      //Node1Weight = Node0Weight = 0.5D;
      //Node1Weight = 1D - Node0Weight;
      //Node0Weight = Math.Round(Node0Weight, precision) / totalWeight;
      //Node1Weight = Math.Round(Node1Weight, precision) / totalWeight;

      //double totalWeight = Node1Weight + Node0Weight;
      //if (totalWeight != 1D)
      //  throw new Exception("Weight normalisation error");

    }

    /*public void CopyToVertex(ref Vertex vertex)
    {
      vertex.Node0Index = Node0Index;
      vertex.Node0Weight = Node0Weight;
      vertex.Node1Index = Node1Index;
      vertex.Node1Weight = Node1Weight;
    }*/
  }
}