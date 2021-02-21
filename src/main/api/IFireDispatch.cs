using System.Collections.Generic;

namespace Firefighters.api
{
  public interface IFireDispatch
  {
    /// <summary>
    /// Hires a number of firefighters
    /// </summary>
    /// <param name="numFirefighters"></param>
    void SetFirefighters(int numFirefighters);

    /// <summary>
    /// Get the list of firefighters
    /// </summary>
    /// <returns>List of firefighters</returns>
    IList<IFirefighter> GetFirefighters();

    /// <summary>
    /// The FireDispatch will be notified of burning buildings via this method. It will then dispatch the
    /// firefighters and extinguish the fires. We want to optimize for total distance traveled by all firefighters
    /// </summary>
    /// <param name="burningBuildings">list of locations with burning buildings</param>
    void DispatchFirefighers(params CityNode[] burningBuildings);
  }
}
