namespace Firefighters.api
{
  public interface IBuilding
  {
    /// <summary>
    /// Get the location of this building
    /// </summary>
    /// <returns><see cref="CityNode"/> representing the location</returns>
    CityNode GetLocation();

    /// <summary>
    /// Find out if the building is currently on fire
    /// </summary>
    /// <returns>true if the building is burning, otherwise false</returns>
    bool IsBurning();

    /// <summary>
    /// Find out if the building is fireproof
    /// </summary>
    /// <returns>true if the building is fireproof, otherwise false</returns>
    bool IsFireproof();

    /// <summary>
    /// Extinguish the fire in the building
    /// </summary>
    /// <exception cref="NoFireFoundException">if the building is not on fire</exception>
    void ExtinguishFire();

    /// <summary>
    /// Sets the building on fire. This method should only be used to set up the scenario.
    /// </summary>
    /// <exception cref="FireproofBuildingException">if the building is fireproof</exception>
    void SetFire();
  }
}
