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


        public Habitability HabitabilityRand()
        {

            Int32 j = rnd.Next(1, 10001);
            if (j >9999)
            {

             return Habitability.intelligentForms;
            }
            else
                if (j > 9990)
                   return Habitability.complexForms;
                else
                    if (j >9900)
                       return Habitability.simplestForms;
                    else return Habitability.noLife;


        }



        void ConstructAsteroid()
               {
            Int32 J=   rnd.Next(100, 2000);

            for (Int32 i = 0; J > i; i++)
            {
                AsteroidFamilyObj.Add(new Asteroid()
                { Name = "Asteroid N "+ i,
                   Mass = rnd.Next(1, 3),
                   OrbitCircumference =this.OrbitCircumference* rnd.Next(90, 111)/100,
                  Hab = HabitabilityRand()
                });

               

            }
        }

    }
}
