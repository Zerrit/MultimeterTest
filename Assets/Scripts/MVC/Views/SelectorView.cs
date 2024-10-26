using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MultimeterTest.MVC.Views
{
    public class SelectorView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<float> OnAngleChanged;  

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private Color _unselectColor;
        [SerializeField] private Color _selectColor;

        private bool _isActive;
        private Material _material;

        private void Start()
        {
            _material = _meshRenderer.material;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isActive = true;
            _material.color = _selectColor;

            Debug.Log("Selector has been activated");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isActive = false;
            _material.color = _unselectColor;

            Debug.Log("Selector has been deactivated");
        }

        private void Update()
        {
            if (!_isActive)
            {
                return;
            }

            var scrollValue = Input.GetAxis("Mouse ScrollWheel");

            if (scrollValue == 0)
            {
                return;
            }

            var rotationValue = scrollValue * _rotationSpeed;
            _transform.eulerAngles += new Vector3(0f, 0f, rotationValue);

            OnAngleChanged?.Invoke(_transform.eulerAngles.z);
        }
    }
}