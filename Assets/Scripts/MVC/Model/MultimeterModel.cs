using MultimeterTest.Tools;
using UnityEngine;

namespace MultimeterTest.MVC.Model
{
    public class MultimeterModel : IMultimeterModel
    {
        public ReactiveProperty<MultimeterMode> SelectedMode { get; private set; }
        public ReactiveProperty<float> SelectedModeValue { get; private set; }

        public float Resistance { get; } // Ом
        public float Power { get; }      // Вт
        public float ACVoltage { get; }  // В
        public float DCVoltage { get; private set; }  // В
        public float Amperage { get; private set; }   // A

        public const float Neutral = 0;

        public MultimeterModel(float resistance, float power, float aCVoltage)
        {
            Resistance = resistance;
            Power = power;
            ACVoltage = aCVoltage;
        }

        public void Initialize()
        {
            CalculateParameters();

            SelectedMode = new ReactiveProperty<MultimeterMode>();
            SelectedModeValue = new ReactiveProperty<float>();
        }

        public void ChangeMode(MultimeterMode newMode)
        {
            switch (newMode)
            {
                case MultimeterMode.Neutral:
                {
                    SelectedModeValue.Value = Neutral;
                    break;
                }
                
                case MultimeterMode.DCVoltage:
                {
                    SelectedModeValue.Value = DCVoltage;
                    break;
                }
                
                case MultimeterMode.ACVoltage:
                {
                    SelectedModeValue.Value = ACVoltage;
                    break;
                }
                
                case MultimeterMode.Amperage:
                {
                    SelectedModeValue.Value = Amperage;
                    break;
                }
                
                case MultimeterMode.Resistance:
                {
                    SelectedModeValue.Value = Resistance;
                    break;
                }
            }
            
            SelectedMode.Value = newMode;
        }

        private void CalculateParameters()
        {
            Amperage = Mathf.Sqrt(Power / Resistance);
            DCVoltage = Power / Amperage;
        }
    }
}
