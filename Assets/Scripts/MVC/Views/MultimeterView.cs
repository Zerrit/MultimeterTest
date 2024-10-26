using System;
using MultimeterTest.MVC.Model;
using TMPro;
using UnityEngine;

namespace MultimeterTest.MVC.Views
{
    public class MultimeterView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _multimeterDisplayText;
        [SerializeField] private Transform _selector;
        [SerializeField] private float _rotationSpeed;

        private IMultimeterModel _model;

        public void Initialize(IMultimeterModel model)
        {
            _model = model;
            
            _model.SelectedModeValue.Subscribe(UpdateDisplayText);
        }
        
        private void Update()
        {
            var scrollDelta = Input.GetAxis("Mouse ScrollWheel") * _rotationSpeed;
            _selector.eulerAngles += new Vector3(0f, 0f, scrollDelta);
            
            DefineMode(_selector.eulerAngles.z);
        }

        private void UpdateDisplayText(float value)
        {
            _multimeterDisplayText.text = value.ToString("F2");
        }

        private void DefineMode(float selectorRotation)
        {
            if (Math.Abs(selectorRotation - 90f) < 1f)
            {
                _model.ChangeMode(MultimeterMode.Neutral);
            }
            else if (selectorRotation >= 0 & selectorRotation < 90)
            {
                _model.ChangeMode(MultimeterMode.DCVoltage);
            }
            else if (selectorRotation > 90 & selectorRotation <= 180)
            {
                _model.ChangeMode(MultimeterMode.ACVoltage);
            }
            else if (selectorRotation > 180 & selectorRotation <= 270)
            {
                _model.ChangeMode(MultimeterMode.Amperage);
            }
            else if (selectorRotation > 270 & selectorRotation < 360)
            {
                _model.ChangeMode(MultimeterMode.Resistance);
            }
        }
    }
}
