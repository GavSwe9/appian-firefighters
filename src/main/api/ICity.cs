namespace Firefighters.api
{
  public interface ICity
  {
    /// <summary>
    /// Get the city's FireStation. The FireStation is fireproof
    /// </summary>
    /// <returns><see cref="Building"/> representing the FireStation</returns>
    IBuilding GetFireStation();

    /// <summary>
    /// Get the city's FireDispatch.
    /// </summary>
    /// <returns>the city's <see cref="FireDispatch"/></returns>
    IFireDispatch GetFireDispatch();

    /// <summary>
    /// Get the X dimension of the city
    /// </summary>
    /// <returns>the X dimension of the city</returns>
    int GetXDimension();

    /// <summary>
    /// Get the Y dimension of the city
    /// </summary>
    /// <returns>the Y dimension of the city</returns>
    int GetYDimension();

    /// <summary>
    /// Get the building at the given coordinates
    /// </summary>
    /// <param name="xCoordinate"></param>
    /// <param name="yCoordinate"></param>
    /// <returns>the <see cref="Building"/> at these coordinates</returns>
    /// <exception cref="OutOfCityBoundsException">if the coordinates are out of bounds for this city</exception>
    IBuilding GetBuilding(int xCoordinate, int yCoordinate);

    /// <summary>
    /// Get the building at the given location
    /// </summary>
    /// <param name="cityNode"></param>
    /// <returns>the <see cref="Building"/> at this location</returns>
    /// <exception cref="OutOfCityBoundsException">if the location is out of bounds for this city</exception>
    IBuilding GetBuilding(CityNode cityNode);
  }
}
