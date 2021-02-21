using System;

namespace Firefighters.api.exceptions
{
  public class NoFireFoundException : Exception
  {
    public NoFireFoundException() : base("This building cannot be extinguished because there is no fire!")
    {
    }
  }
}
