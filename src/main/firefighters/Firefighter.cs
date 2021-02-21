using Firefighters.api;
using System;

namespace Firefighters.firefighters
{
    public class Firefighter : api.IFirefighter
    {
        private CityNode location;
        private int distanceTraveled;

        public Firefighter(CityNode firestationLocation)
        {
            location = firestationLocation;
            distanceTraveled = 0;
        }

        public CityNode GetLocation()
        {
            return location;
        }

        public void SetLocation(CityNode cityNode)
        {
            location = cityNode;
        }

        public int DistanceTraveled()
        {
            return distanceTraveled;
        }

        public void SetDistanceTraveled(int distance)
        {
            distanceTraveled += distance;
        }

    }
}
