using System;

namespace OopPlanets
{
    public class Terrestrial : APlanet
    {
        public override Composition Composition
        {
            get
            {
                return Composition.Rock;
            }
        }

        public Terrestrial(string name, double mass, double diameter, double aphelion, double perihelion) : base(name, mass, diameter, aphelion, perihelion)
        {
           
        }

    }
}
