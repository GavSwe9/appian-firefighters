using System;

namespace Firefighters.api.exceptions
{
  public class FireproofBuildingException : Exception
  {
    public FireproofBuildingException() : base("This building is fireproof and cannot be set on fire")
    {
    }
  }
}
