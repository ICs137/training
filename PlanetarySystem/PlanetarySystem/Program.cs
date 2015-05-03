using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            PlanetarySystem PlanetarySystemObj = new PlanetarySystem();


            AsteroidFamilyBuilder asteroidFamilyBuilder = new AsteroidFamilyBuilder() {Name="Field", OrbitCircumference=1000 };

         PlanetarySystemObj.Add(  asteroidFamilyBuilder.Construct());

         PlanetarySystemObj.Add(new Star() {Name="Starrrr", Mass=9999999, NuclearFusion=true, SolarLuminosity=14  });
         PlanetarySystemObj.Add(new Planet() { Name = "asdsad", Mass = 11, });
         Planet planet = new Planet() { Name = "nnnn", Mass = 20  };
         planet.Add(new Satellite() { Name = "Jj", Hab = Habitability.complexForms, Artificially = false, Mass = 1, OrbitCircumference = 11 });
         planet.Add(new Satellite() { Name = "Jjfd", Hab = Habitability.noLife , Artificially = false, Mass =1, OrbitCircumference = 13 });
         planet.AtmospherePressure = 122;
         planet.Hab = Habitability.noLife;
         planet.NuclearFusion=true;
         PlanetarySystemObj.Add(planet);
         PlanetarySystemObj.Add(new Asteroid() { Name = "asteroid", Hab = Habitability.noLife, Mass = 1, OrbitCircumference = 333 });

         PlanetarySystemObj.SortByMass();
   
         foreach (var i in PlanetarySystemObj)
             Console.WriteLine("{0 }, {1}",i.Name, i.Mass);




        }
    }
}
