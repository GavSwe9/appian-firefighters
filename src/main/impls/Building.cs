using Firefighters.api;
using Firefighters.api.exceptions;

namespace Firefighters.impls
{
  public class Building : IBuilding
  {
    private readonly CityNode location;
    private bool isBurning;
    private readonly bool fireproof;

    public Building(CityNode location)
    {
      this.location = location;
      this.fireproof = false;
      this.isBurning = false;
    }

    protected Building(CityNode location, bool fireproof) : this(location)
    {
      this.fireproof = fireproof;
    }

    public CityNode GetLocation()
    {
      return location;
    }

    public bool IsBurning()
    {
      return isBurning;
    }

    public bool IsFireproof()
    {
      return fireproof;
    }

    public void ExtinguishFire()
    {
      if (isBurning)
      {
        this.isBurning = false;
      }
      else
      {
        throw new NoFireFoundException();
      }
    }

    public void SetFire()
    {
      if (!fireproof)
      {
        this.isBurning = true;
      }
      else
      {
        throw new FireproofBuildingException();
      }
    }
  }
}
