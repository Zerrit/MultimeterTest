using System;
using UnityEngine;

namespace MultimeterTest.MVC.Model
{
    public class MultimeterModel : IMultimeterModel
    {
        public ReactiveProperty<MultimeterMode> SelectedMode { get; private set; }
        public ReactiveProperty<float> SelectedModeValue { get; private set; }
        
        public float Resistance { get; private set; } // Ом
        public float Power { get; private set; } // Вт
        public float Amperage { get; private set; } // A
        public float DCVoltage { get; private set; } // В
        public float ACVoltage { get; private set; } // В

        public const float Neutral = 0;
        
        public MultimeterModel()
        {
            Resistance = 1000;
            Power = 400;
            ACVoltage = 0.01f;
        }

        public void Initialize()
        {
            Calculate();

            SelectedMode = new ReactiveProperty<MultimeterMode>();
            SelectedModeValue = new ReactiveProperty<float>();
        }

        public void ChangeMode(MultimeterMode newMode)
        {
            SelectedMode.Value = newMode;
            
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
        }
        
        private void Calculate()
        {
            Amperage = (float)Math.Round(Mathf.Sqrt(Power / Resistance), 2);
            DCVoltage = (float)Math.Round(Power / Amperage, 2);
        }
    }
}
