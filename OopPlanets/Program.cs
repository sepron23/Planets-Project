using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace OopPlanets
{
    class Program
    {
        static void Main(string[] args)
        {
            Terrestrial mercury = new Terrestrial("Mercury", 0.055, 4480, 6981690, 46001200);
            Terrestrial venus = new Terrestrial("Venus", 0.815, 12103.6, 108939000, 10777000);
            // Terrestrial earth = new Terrestrial("Earth", 1, 6384.4, 152100000, 147095000);
            Terrestrial mars = new Terrestrial("Mars", 0.107, 6779, 249200000, 206700000);
            Jovian jupiter = new Jovian("Jupiter", 317.8, 142984, 816520000, 740520000);
            Jovian saturn = new Jovian("Saturn", 95.2, 116460, 1514500000, 1352550000);
            Jovian uranus = new Jovian("Uranus", 14.5, 50724, 3.00841e+9, 2.74213e+9);
            Jovian neptune = new Jovian("Neptune", 17.1, 49244, 4.5373e+9, 4.45951e+9);


            APlanet[] planets = { mercury, venus, mars, jupiter, saturn , uranus, neptune};

            Terrestrial planet = (Terrestrial)GetPlanetData();
            GetInfo(planet);

            //bool run = false;

            //while (run == false)
            //{
            //Console.WriteLine("What would you like to see?");
            //string input = Console.ReadLine();
            //input = input.ToLower();

            //if (input == "list")
            //{
            //    OrderAlphabetically(planets);
            //}

            //else if (input == "mass")
            //{
            //    OrderByMass(planets);
            //}

            //else if (input == "diameter")
            //{
            //    OrderByDiameter(planets);
            //}

            //else if (input == "planet")
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("Enter the planet name");
            //        string pName = Console.ReadLine();
            //        if (pName == "exit")
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            Planet(pName, planets);
            //        }
            //    }
            //}

            //else if (input == "help" || input == "")
            //{
            //    Console.WriteLine("Here are the commands");
            //    Console.WriteLine("\"Diameter\" - Prints an ordered by diameter list of plantes");
            //    Console.WriteLine("\"Mass\" - Prints an ordered by mass list of planets");
            //    Console.WriteLine("\"List\" - Prints an alphabetically ordered list of planets");
            //    Console.WriteLine("\"Planet\" - You will be asked to name a planet, then you willbe given all the information about said planet");
            //}

            //else if(input == "exit")
            //{
            //    run = true;
            //}

        }

        public static void Planet(string pName, APlanet[] planets)
        {
            bool ok = planets.Any(x => x.Name == pName);
            if (ok)
            {
                var chosen = planets.FirstOrDefault(x => x.Name == pName);
                GetInfo(chosen);
            }

            else
            {
                Console.WriteLine("Invalid planet name please try again");
            }
        }

        public static void OrderByMass(APlanet[] planets)
        {
            var sortedPlanets = OrderPlanets("Mass", planets);
            foreach (APlanet p in sortedPlanets)
            {
                Console.WriteLine(p.Name + ": mass is " + p.Mass + " solar masses");
            }
        }

        public static void OrderByDiameter(APlanet[] planets)
        {
            var sortedPlanets = OrderPlanets("Diameter", planets);
            foreach (APlanet p in sortedPlanets)
            {
                Console.WriteLine(p.Name + ": diameter is " + p.Diameter + " Km");
            }
        }

        public static void OrderAlphabetically(APlanet[] planets)
        {
            var sortedPlanets = OrderPlanets("Name", planets);
            foreach(APlanet p in sortedPlanets)
            {
                Console.WriteLine(p.Name);
            }
        }

        private static IOrderedEnumerable<APlanet> OrderPlanets(string orderby, IEnumerable<APlanet> planets)
        {
            var dynamicProp = typeof(APlanet).GetProperty(orderby);
            var sortedPlanets = planets.OrderBy(p => dynamicProp.GetValue(p));

            return sortedPlanets;
        }

        public static void GetInfo(APlanet planet)
        {
            Console.WriteLine("Planet " + planet.Name + " is a planet made from " + planet.Composition);
            Console.WriteLine("It has a mass of " + planet.Mass);
            Console.WriteLine("It has a diameter of " + planet.Diameter);
            Console.WriteLine("It's aphelion is " + planet.Aphelion);
            Console.WriteLine("It's Perihelion is " + planet.Perihelion);
        }

        public static object GetPlanetData()
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=----WebKitFormBoundaryf2KT3A1uABg8AJkr");
                //client.Headers.Add(":method", "POST");
                //client.Headers.Add(":path", "/w/api.php");
                //client.Headers.Add(":scheme", "https");
                //client.Headers.Add(":authority", "en.wikipedia.org");
                //client.Headers.Add(HttpRequestHeader.Accept, "text/plain, */*; q=0.01");
                //string Params = "action=parse&format=json&page=Earth";
                string response = client.UploadString(new Uri("https://en.wikipedia.org/w/api.php?action=parse&format=json&page=Earth"), "POST");
                var planet = JsonConvert.DeserializeObject<Terrestrial>(response);
                return planet;
            }
        }
    }
}
