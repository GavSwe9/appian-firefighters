using Firefighters.api;

namespace Firefighters.impls
{
  public class FireStation : Building
  {
    public FireStation(CityNode location) : base(location, true)
    {
    }
  }
}
