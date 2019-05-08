using System;

namespace OopPlanets
{
    public abstract class APlanet
    {
        public string Name { get; protected set; }
        public double Mass { get; protected set; }
        public double Diameter { get; protected set; }
        public double Aphelion { get; protected set; } // Furthest point from the sun
        public double Perihelion { get; protected set; } // Closest distance from the sun
        public abstract Composition Composition { get; }


        protected APlanet(string name, double mass, double diameter, double aphelion, double perihelion)
        {
            Name = name;
            Mass = mass;
            Diameter = diameter;
            Aphelion = aphelion;
            Perihelion = perihelion;
        }
    }
}
