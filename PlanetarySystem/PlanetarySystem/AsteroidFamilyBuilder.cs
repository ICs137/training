using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class AsteroidFamilyBuilder
    {
        public string Name { get; set; }
        public Double OrbitCircumference { get; set; }
        public ICollection<Asteroid> Asteroids { get; set; }
        private AsteroidFamily AsteroidFamilyObj = new AsteroidFamily();
        public AsteroidFamilyBuilder ()
        {
            Asteroids = new List<Asteroid>();
        }
        Random rnd = new Random();

        public  AsteroidFamily Construct()
        {
                    ConstructFamily();
                    ConstructAsteroid();
            return AsteroidFamilyObj;
        }


        protected void ConstructFamily()
        {
            AsteroidFamilyObj.Name = this.Name;
            AsteroidFamilyObj.OrbitCircumference = this.OrbitCircumference;
          
        }


        void ConstructAsteroid()
               {
                
            for (Int32 i = 0; rnd.Next(10, 200)  > i; i++)
            {
                AsteroidFamilyObj.Add(new Asteroid(1)
                { Name = "Asteroid N "+ i,
                   Mass = rnd.Next(1, 2),
                   OrbitCircumference =this.OrbitCircumference* rnd.Next(8, 12)/10
                 
                });

               

            }
        }

    }
}
