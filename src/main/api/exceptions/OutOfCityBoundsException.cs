using System;

namespace Firefighters.api.exceptions
{
  public class OutOfCityBoundsException : Exception
  {
    public OutOfCityBoundsException() : base("This node is out of bounds!")
    {
    }
  }
}
