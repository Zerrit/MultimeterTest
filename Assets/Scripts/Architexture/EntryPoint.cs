using MultimeterTest.MVC;
using MultimeterTest.MVC.Model;
using MultimeterTest.MVC.Views;
using UnityEngine;

namespace MultimeterTest.Architexture
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Входные параметры мультиметра"),
         SerializeField] private float _resistanceValue = 1000f;
        [SerializeField] private float _powerValue = 400f;
        [SerializeField] private float _aCVoltage = 0.01f;

        [Header("Ссылки для инициализации"),
         SerializeField] private MultimeterView _multimeterView;
        [SerializeField] private MultimeterUIView _multimeterUiView;

        private MultimeterController _multimeterController;

        private void Start()
        {
            var model = new MultimeterModel(_resistanceValue, _powerValue, _aCVoltage);

            _multimeterController = new MultimeterController(model, _multimeterView, _multimeterUiView);
            _multimeterController.Initialize();
        }
    }
}