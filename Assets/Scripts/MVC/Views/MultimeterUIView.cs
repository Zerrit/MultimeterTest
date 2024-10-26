using MultimeterTest.MVC.Model;
using TMPro;
using UnityEngine;

namespace MultimeterTest.MVC.Views
{
    public class MultimeterUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resistanceText;
        [SerializeField] private TextMeshProUGUI _amperageText;
        [SerializeField] private TextMeshProUGUI _dCVoltageText;
        [SerializeField] private TextMeshProUGUI _aCVoltageText;

        private IMultimeterModel _model;
        
        public void Initialize(IMultimeterModel model)
        {
            ClearValue();
            
            _model = model;
            _model.SelectedMode.Subscribe(UpdateValuesText);
        }
        
        private void UpdateValuesText(MultimeterMode mode)
        {
            ClearValue();

            switch (mode)
            {
                case MultimeterMode.DCVoltage:
                {
                    _dCVoltageText.text = $"V {_model.SelectedModeValue.Value:F2}";
                    break;
                }
                
                case MultimeterMode.ACVoltage:
                {
                    _aCVoltageText.text = $"~ {_model.SelectedModeValue.Value:F2}";
                    break;
                }
                
                case MultimeterMode.Amperage:
                {
                    _amperageText.text = $"A {_model.SelectedModeValue.Value:F2}";
                    break;
                }
                
                case MultimeterMode.Resistance:
                {
                    _resistanceText.text = $"Ω {_model.SelectedModeValue.Value:F2}";
                    break;
                }
            }
        }

        private void ClearValue()
        {
            _resistanceText.text = $"Ω 0";
            _amperageText.text = $"A 0";
            _dCVoltageText.text = $"V 0";
            _aCVoltageText.text = $"~ 0";
        }

        private void OnDestroy()
        {
            _model.SelectedMode.Unsubscribe(UpdateValuesText);
        }
    }
}