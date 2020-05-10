using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicSettings : MonoBehaviour
{



    [SerializeField] private int currentGraphics; //this is only for debugging reasons to see if the dropdown works

    public TMP_Dropdown graphicsDropDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (graphicsDropDown.value == 0) {
            SetUltra();
        }

        if (graphicsDropDown.value == 1) {
            SetVeryHigh();
        }

        if (graphicsDropDown.value == 2) {
            SetHigh();
        }

        if (graphicsDropDown.value == 3) {
            SetMedium();
        }

        if (graphicsDropDown.value == 4) {
            SetLow();
        }

        if (graphicsDropDown.value == 5) {
            SetVeryLow();
        }

        
    }

    public void SetUltra() {
        QualitySettings.SetQualityLevel(5, true);

        currentGraphics = QualitySettings.GetQualityLevel();
    }

    public void SetVeryHigh() {
        QualitySettings.SetQualityLevel(4, true);

        currentGraphics = QualitySettings.GetQualityLevel();
    }

    public void SetHigh() {
        QualitySettings.SetQualityLevel(3, true);

        currentGraphics = QualitySettings.GetQualityLevel();
    }

    public void SetMedium() {
        QualitySettings.SetQualityLevel(2, true);

        currentGraphics = QualitySettings.GetQualityLevel();
    }

    public void SetLow() {
        QualitySettings.SetQualityLevel(1, true);

        currentGraphics = QualitySettings.GetQualityLevel();
    }

    public void SetVeryLow() {
        QualitySettings.SetQualityLevel(0, true);

        currentGraphics = QualitySettings.GetQualityLevel();
    }
}
