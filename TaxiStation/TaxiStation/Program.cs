using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxiStation TaxiStationExample = new TaxiStation();
            TaxiStationExample.Add(new Volkswagen() 
            { ModelName = VolkswagenList.Jetta, FuelConsumption = 6.8, MaxSpeed = 220, Price=15700,CapacityPassengert=4,ManufacturedDate=new DateTime(2014,12,01),});

            TaxiStationExample.Add(new Volkswagen() 
            { ModelName = VolkswagenList.Т5, FuelConsumption = 8.8, MaxSpeed = 130, Price=13500,CapacityPassengert=8,ManufacturedDate=new DateTime(2014,12,01),});

            TaxiStationExample.Add(new Mercedes() 
            { ModelName = MercedesList.W222, FuelConsumption = 9.6, MaxSpeed = 250, Price = 135000, CapacityPassengert = 4, ManufacturedDate = new DateTime(2015, 10, 01), });

            TaxiStationExample.Add(new Mercedes() 
            { ModelName = MercedesList.w906, FuelConsumption = 12.2, MaxSpeed = 150, Price = 35000, CapacityPassengert = 8, ManufacturedDate = new DateTime(2009, 10, 01), });


            TaxiStationExample.Add(new Audi() 
            { ModelName = AudiList.A4, FuelConsumption = 6.5, MaxSpeed = 150, Price = 36000, CapacityPassengert = 4, ManufacturedDate = new DateTime(2013, 10, 01), });


            TaxiStationExample.Add(new Audi() { ModelName = AudiList.A8, FuelConsumption = 10.5, MaxSpeed =250, Price = 90000, CapacityPassengert = 4, ManufacturedDate = new DateTime(2014, 09, 01), });
            Console.WriteLine();

            Console.WriteLine("полная стоимость авто = {0} ", TaxiStationExample.GetFullPrice());

            TaxiStationExample.SortWithDict("FuelConsumption");




            Console.WriteLine();


            foreach (var i in TaxiStationExample )
            {

                i.GetInfoCar();

            }



            Console.WriteLine();

            foreach (var i in TaxiStationExample.GetCarBySpeed(200,280))
            {

                i.GetInfoCar();


            }




        }
    }
}
