using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class Asteroid : SpaceItem, IMoveItem
    {
       public Habitability Hab { get; set; }
       public Double OrbitCircumference { get; set; }
       Random rnd = new Random();

       public Asteroid() { }
       public Asteroid(int a) { HabitabilityRand(); }
       public  void HabitabilityRand()
       {
         if(  rnd.Next(1,1000000)>999999)
         {

             Hab = Habitability.intelligentForms;

             if (rnd.Next(1, 1000000) > 999990)
                 Hab=Habitability.complexForms;
             if (rnd.Next(1, 1000000) > 999900)
                 Hab = Habitability.simplestForms;
             else Hab = Habitability.noLife;

         }
       }




    }
}

