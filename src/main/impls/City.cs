using Firefighters.api;
using Firefighters.api.exceptions;
using Firefighters.firefighters;

namespace Firefighters.impls
{
  public class City : ICity
  {
    private readonly FireStation fireStation;
    private readonly Building[,] buildingGrid;
    private FireDispatch fireDispatch;

    public City(int xDimension, int yDimension, CityNode fireStationLocation)
    {
      ValidateCityDimensions(xDimension, yDimension);
      this.fireStation = new FireStation(fireStationLocation);
      this.buildingGrid = InitBuildingGrid(xDimension, yDimension);
    }

    public IBuilding GetFireStation()
    {
      return fireStation;
    }

    public IFireDispatch GetFireDispatch()
    {
      if (fireDispatch == null)
      {
        fireDispatch = new FireDispatch(this);
      }

      return fireDispatch;
    }

    public int GetXDimension()
    {
      return buildingGrid.GetLength(0);
    }

    public int GetYDimension()
    {
      return buildingGrid.GetLength(1);
    }

    public IBuilding GetBuilding(int xCoordinate, int yCoordinate)
    {
      ValidateCoordinate(xCoordinate, yCoordinate);
      return buildingGrid[xCoordinate, yCoordinate];
    }

    public IBuilding GetBuilding(CityNode cityNode)
    {
      return GetBuilding(cityNode.GetX(), cityNode.GetY());
    }

    private Building[,] InitBuildingGrid(int xDimension, int yDimension)
    {
      Building[,] initGrid = new Building[xDimension, yDimension];

      for (int x = 0; x < xDimension; x++)
      {
        for (int y = 0; y < yDimension; y++)
        {
          initGrid[x, y] = InitBuilding(x, y);
        }
      }

      return initGrid;
    }

    private void ValidateCityDimensions(int xDimension, int yDimension)
    {
      if (xDimension < 2)
      {
        throw new InvalidDimensionException(xDimension);
      }
      else if (yDimension < 2)
      {
        throw new InvalidDimensionException(yDimension);
      }
    }

    private Building InitBuilding(int x, int y)
    {
      if (x == fireStation.GetLocation().GetX() && y == fireStation.GetLocation().GetY())
      {
        return fireStation;
      }
      else
      {
        return new Building(new CityNode(x, y));
      }
    }

    private void ValidateCoordinate(int xCoordinate, int yCoordinate)
    {
      if (xCoordinate < 0 || yCoordinate < 0 || xCoordinate >= GetXDimension() ||
          yCoordinate >= GetYDimension())
      {
        throw new OutOfCityBoundsException();
      }
    }
  }
}
