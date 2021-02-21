using System;

namespace Firefighters.api.exceptions
{
  public class InvalidDimensionException : Exception
  {
    public InvalidDimensionException(int invalidDimension) : base("Invalid dimension for a city: " + invalidDimension)
    {
    }
  }
}
