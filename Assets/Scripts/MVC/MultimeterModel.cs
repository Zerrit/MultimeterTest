
using UnityEngine;

namespace MultimeterTest.MVC
{
    public class MultimeterModel 
    {
        public float Resistance { get; private set; } // Ом
        public float Power { get; private set; } // Вт
        public float Amperage { get; private set; }
        public float DCVoltage { get; private set; }
        public float ACVoltage { get; private set; }
        
        public MultimeterModel()
        {
            Resistance = 1000;
            Power = 400;
            ACVoltage = 0.01f;
        }

        private void Calculate()
        {
            Amperage = Mathf.Sqrt(Power / Resistance);
            DCVoltage = Power / Amperage;
        }
    }
}
