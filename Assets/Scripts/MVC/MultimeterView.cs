using TMPro;
using UnityEngine;

namespace MultimeterTest.MVC
{
    public class MultimeterView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _multimeterDisplayText;
        [SerializeField] private Transform _selector;
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            var scrollDelta = Input.GetAxis("Mouse ScrollWheel") * _rotationSpeed;
            _selector.eulerAngles += new Vector3(0f, 0f, scrollDelta);
        }
    }
}
