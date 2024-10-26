using TMPro;
using UnityEngine;

namespace MultimeterTest.MVC
{
    public class MultimeterUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resistanceText;
        [SerializeField] private TextMeshProUGUI _amperageText;
        [SerializeField] private TextMeshProUGUI _dCVoltageText;
        [SerializeField] private TextMeshProUGUI _aCVoltageText;
    }
}