using System;

namespace OopPlanets
{
    public class Jovian : APlanet
    {
        public override Composition Composition
        {
            get
            {
                return Composition.Rock;
            }
        }

        public Jovian(string name, double mass, double diameter, double aphelion, double perihelion) : base(name, mass, diameter, aphelion, perihelion)
        {

        }

       
    }
}
