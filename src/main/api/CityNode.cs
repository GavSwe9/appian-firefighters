using System;

namespace Firefighters.api
{
  /// <summary>
  /// Represents a location in the city
  /// </summary>
  public class CityNode
  {
    private readonly int xCoordinate;
    private readonly int yCoordinate;

    /// <summary>
    /// Build a <see cref="CityNode"/> given coordinates
    /// </summary>
    /// <param name="xCoordinate"></param>
    /// <param name="yCoordinate"></param>
    public CityNode(int xCoordinate, int yCoordinate)
    {
      this.xCoordinate = xCoordinate;
      this.yCoordinate = yCoordinate;
    }

    /// <summary>
    /// Get the X coordinate of this node
    /// </summary>
    /// <returns>the X coordinate of this node</returns>
    public int GetX()
    {
      return xCoordinate;
    }

    /// <summary>
    /// Get the Y coordinate of this node
    /// </summary>
    /// <returns>the Y coordinate of this node</returns>
    public int GetY()
    {
      return yCoordinate;
    }

    public override String ToString()
    {
      return "CityNode{" + "xCoordinate=" + xCoordinate + ", yCoordinate=" + yCoordinate + '}';
    }

    public override bool Equals(object o)
    {
      if (this == o)
        return true;
      if (o == null || this.GetType() != o.GetType())
        return false;
      CityNode cityNode = (CityNode)o;
      return xCoordinate == cityNode.xCoordinate && yCoordinate == cityNode.yCoordinate;
    }

    public override int GetHashCode()
    {
      return xCoordinate ^ yCoordinate;
    }
  }
}
