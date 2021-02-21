namespace Firefighters.api
{
  public interface IFirefighter
  {
    /// <summary>
    /// Get the firefighter's current location. Initially, the firefighter should be at the FireStation
    /// </summary>
    /// <returns><see cref="CityNode"/> representing the firefighter's current location</returns>
    CityNode GetLocation();

    /// <summary>
    /// Get the total distance traveled by this firefighter. Distances should be represented using TaxiCab
    /// Geometry: <see href="https://en.wikipedia.org/wiki/Taxicab_geometry"/>
    /// </summary>
    /// <returns>the total distance traveled by this firefighter</returns>
    int DistanceTraveled();
  }
}
