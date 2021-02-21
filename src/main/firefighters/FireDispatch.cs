using Firefighters.api;
using System;
using System.Collections.Generic;

namespace Firefighters.firefighters
{
    public class FireDispatch : api.IFireDispatch
    {
        private readonly ICity dispatchCity;
        private Firefighter[] firefighters;
        public FireDispatch(ICity city)
        {
            dispatchCity = city;
            
        }

        public void SetFirefighters(int numFirefighters)
        {
            firefighters = new Firefighter[numFirefighters];
            for (int i = 0; i < numFirefighters; i++)
            {
                firefighters[i] = new Firefighter(dispatchCity.GetFireStation().GetLocation());
            }
        }

        public IList<IFirefighter> GetFirefighters()
        {
            return firefighters;
        }

        public void DispatchFirefighers(params CityNode[] burningBuildings)
        {
            foreach (CityNode burningBuilding in burningBuildings)
            {
                Tuple<Firefighter, int> nearestFirefighterResults = FindClosestFirefighter(burningBuilding, firefighters);
                nearestFirefighterResults.Item1.SetLocation(burningBuilding);
                nearestFirefighterResults.Item1.SetDistanceTraveled(nearestFirefighterResults.Item2);

                dispatchCity.GetBuilding(burningBuilding).ExtinguishFire();
            }
        }

        private Tuple<Firefighter,int> FindClosestFirefighter(CityNode burningBuilding, Firefighter[] firefighters)
        {
            Firefighter nearestFirefighter = firefighters[0];
            int minDistance = int.MaxValue;

            foreach (Firefighter firefighter in firefighters)
            {
                int distance = CalculateDistance(burningBuilding, firefighter.GetLocation());
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestFirefighter = firefighter;
                }
            }

            return new Tuple<Firefighter,int>(nearestFirefighter, minDistance);
        }

        private int CalculateDistance(CityNode node1, CityNode node2)
        {
            return Math.Abs(node1.GetX() - node2.GetX()) + Math.Abs(node1.GetY() - node2.GetY());
        }
    }
}
