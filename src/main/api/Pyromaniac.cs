namespace Firefighters.api
{
  /// <summary>
  /// Utility class to set fires in a city
  /// </summary>
  public class Pyromaniac
  {
    /// <summary>
    /// Sets a number of fires <paramref name="numFires"/> at <paramref name="victimLocations"/> in the given <paramref name="victimCity"/>
    /// </summary>
    /// <param name="victimCity">City to be set on fire</param>
    /// <param name="victimLocations">Locations to be set on fire</param>
    /// <exception cref="FireproofBuildingException">if one of the buildings in question is fireproof</exception>
    public static void SetFires(ICity victimCity, CityNode[] victimLocations)
    {
      foreach(CityNode location in victimLocations) {
        SetFire(victimCity, location);
      }
    }

    /// <summary>
    /// Sets a fire at the <paramref name="location"/> in the given <paramref name="victimCity"/>
    /// </summary>
    /// <param name="victimCity">City to be set on fire</param>
    /// <param name="location">Location to be set on fire</param>
    /// <exception cref="FireproofBuildingException">if one of the buildings in question is fireproof</exception>
    public static void SetFire(ICity victimCity, CityNode location)
    {
      victimCity.GetBuilding(location).SetFire();
    }
  }
}
