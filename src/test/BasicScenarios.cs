using Firefighters.api;
using Firefighters.impls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Firefighters.scenarios
{
    [TestClass]
    public class BasicScenarios
    {
        [TestMethod]
        public void SingleFire()
        {
            ICity basicCity = new City(5, 5, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();
            
            CityNode fireNode = new CityNode(0, 1);
            Pyromaniac.SetFire(basicCity, fireNode);

            fireDispatch.SetFirefighters(1);
            fireDispatch.DispatchFirefighers(fireNode);
            Assert.IsFalse(basicCity.GetBuilding(fireNode).IsBurning());
        }

        [TestMethod]
        public void SingleFireDistanceTraveledDiagonal()
        {
            ICity basicCity = new City(2, 2, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();

            // Set fire on opposite corner from Fire Station
            CityNode fireNode = new CityNode(1, 1);
            Pyromaniac.SetFire(basicCity, fireNode);

            fireDispatch.SetFirefighters(1);
            fireDispatch.DispatchFirefighers(fireNode);

            IFirefighter firefighter = fireDispatch.GetFirefighters()[0];
            Assert.AreEqual(2, firefighter.DistanceTraveled());
            Assert.AreEqual(fireNode, firefighter.GetLocation());
        }

        [TestMethod]
        public void SingleFireDistanceTraveledAdjacent()
        {
            ICity basicCity = new City(2, 2, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();

            // Set fire on adjacent X position from Fire Station
            CityNode fireNode = new CityNode(1, 0);
            Pyromaniac.SetFire(basicCity, fireNode);

            fireDispatch.SetFirefighters(1);
            fireDispatch.DispatchFirefighers(fireNode);

            IFirefighter firefighter = fireDispatch.GetFirefighters()[0];
            Assert.AreEqual(1, firefighter.DistanceTraveled());
            Assert.AreEqual(fireNode, firefighter.GetLocation());
        }

        [TestMethod]
        public void SimpleDoubleFire()
        {
            ICity basicCity = new City(2, 2, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();

            CityNode[] fireNodes = {
              new CityNode(0, 1),
              new CityNode(1, 1)};
            Pyromaniac.SetFires(basicCity, fireNodes);

            fireDispatch.SetFirefighters(1);
            fireDispatch.DispatchFirefighers(fireNodes);

            IFirefighter firefighter = fireDispatch.GetFirefighters()[0];
            Assert.AreEqual(2, firefighter.DistanceTraveled());
            Assert.AreEqual(fireNodes[1], firefighter.GetLocation());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[0]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[1]).IsBurning());
        }

        [TestMethod]
        public void DoubleFirefighterDoubleFire()
        {
            ICity basicCity = new City(2, 2, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();

            CityNode[] fireNodes = {
              new CityNode(0, 1),
              new CityNode(1, 0)};
            Pyromaniac.SetFires(basicCity, fireNodes);

            fireDispatch.SetFirefighters(2);
            fireDispatch.DispatchFirefighers(fireNodes);

            IList<IFirefighter> firefighters = fireDispatch.GetFirefighters();
            int totalDistanceTraveled = 0;
            bool firefighterPresentAtFireOne = false;
            bool firefighterPresentAtFireTwo = false;
            foreach (IFirefighter firefighter in firefighters)
            {
                totalDistanceTraveled += firefighter.DistanceTraveled();

                if (firefighter.GetLocation() == fireNodes[0])
                {
                    firefighterPresentAtFireOne = true;
                }
                if (firefighter.GetLocation() == fireNodes[1])
                {
                    firefighterPresentAtFireTwo = true;
                }
            }

            Assert.AreEqual(2, totalDistanceTraveled);
            Assert.IsTrue(firefighterPresentAtFireOne);
            Assert.IsTrue(firefighterPresentAtFireTwo);
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[0]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[1]).IsBurning());
        }

        // Two tests to make sure firefighters are picking up their nearest fire after leaving the station
        [TestMethod]
        public void ThreeFiresTwoFirefighters()
        {
            ICity basicCity = new City(5, 5, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();

            //CityNode fireNode = new CityNode(2, 3);
            //Pyromaniac.SetFire(basicCity, fireNode);

            CityNode[] fireNodes = {
                new CityNode(3, 4),
                new CityNode(1, 1),
                new CityNode(4, 4)
            };
            Pyromaniac.SetFires(basicCity, fireNodes);

            fireDispatch.SetFirefighters(2);
            fireDispatch.DispatchFirefighers(fireNodes);

            // Check all buildings
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[0]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[1]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[2]).IsBurning());

            // Check location and distance traveled of first firefighter
            Assert.IsTrue(fireDispatch.GetFirefighters()[0].GetLocation().GetX() == 4);
            Assert.IsTrue(fireDispatch.GetFirefighters()[0].GetLocation().GetY() == 4);
            Assert.IsTrue(fireDispatch.GetFirefighters()[0].DistanceTraveled() == 8);

            // Check location and distance traveled of second firefighter
            Assert.IsTrue(fireDispatch.GetFirefighters()[1].GetLocation().GetX() == 1);
            Assert.IsTrue(fireDispatch.GetFirefighters()[1].GetLocation().GetY() == 1);
            Assert.IsTrue(fireDispatch.GetFirefighters()[1].DistanceTraveled() == 2);
        }

        [TestMethod]
        public void ThreeFiresTwoFirefighters2()
        {
            ICity basicCity = new City(10, 10, new CityNode(0, 0));
            IFireDispatch fireDispatch = basicCity.GetFireDispatch();

            CityNode[] fireNodes = {
                new CityNode(3, 4),
                new CityNode(1, 1),
                new CityNode(0, 1),
                new CityNode(5, 9),
                new CityNode(1, 9)
            };
            Pyromaniac.SetFires(basicCity, fireNodes);

            fireDispatch.SetFirefighters(2);
            fireDispatch.DispatchFirefighers(fireNodes);

            // Check all buildings
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[0]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[1]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[2]).IsBurning());
            Assert.IsFalse(basicCity.GetBuilding(fireNodes[3]).IsBurning());
            
            // Check location and distance traveled of first firefighter
            Assert.IsTrue(fireDispatch.GetFirefighters()[0].GetLocation().GetX() == 1);
            Assert.IsTrue(fireDispatch.GetFirefighters()[0].GetLocation().GetY() == 9);
            Assert.IsTrue(fireDispatch.GetFirefighters()[0].DistanceTraveled() == 18);

            // Check location and distance traveled of second firefighter
            Assert.IsTrue(fireDispatch.GetFirefighters()[1].GetLocation().GetX() == 0);
            Assert.IsTrue(fireDispatch.GetFirefighters()[1].GetLocation().GetY() == 1);
            Assert.IsTrue(fireDispatch.GetFirefighters()[1].DistanceTraveled() == 3);
        }
    }
}
