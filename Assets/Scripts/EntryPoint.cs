using MultimeterTest.MVC;
using UnityEngine;

namespace MultimeterTest
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MultimeterView _multimeterView;
        [SerializeField] private MultimeterUIView _multimeterUiView;

        private void Start()
        {
            var multimeterController = new MultimeterController(new MultimeterModel(), _multimeterView, _multimeterUiView);
        }
    }
}