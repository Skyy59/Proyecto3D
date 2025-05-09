using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lock : MonoBehaviour
{

    [SerializeField] private TMP_Text _numberText;
    [SerializeField] private int _currentNumber = 0;

    private void Start()
    {
        UpdateNumberDisplay();
    }

    

    public void CycleNumber()
    {
        _currentNumber++;

        // Si pasa de 9, volver a 0
        if (_currentNumber > 9)
        {
            _currentNumber = 0;
        }

        UpdateNumberDisplay();
    }

    private void UpdateNumberDisplay()
    {
        _numberText.text = _currentNumber.ToString();
    }
}
