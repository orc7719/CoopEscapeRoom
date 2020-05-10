using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicSettings : MonoBehaviour
{



    [SerializeField] private int currentGraphics; //this is only for debugging reasons to see if the dropdown works

    public TMP_Dropdown graphicsDropDown;

    public TMP_Dropdown AntiAliasingDropDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //quality settings if statements

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

        //Anti Aliasing if statements
        if (AntiAliasingDropDown.value == 0) {
            disabledAnti();
        }

        if (AntiAliasingDropDown.value == 1) {
            twoTimesAnti();
        }

        if (AntiAliasingDropDown.value == 2) {
            fourTimesAnti();
        }

        if (AntiAliasingDropDown.value == 3) {
            eightTimesAnti();
        }
        
    }
    //All Quality Settings
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

    //All Anti Aliasing Settings
    public void disabledAnti() {
        QualitySettings.antiAliasing = 0;
    }

    public void twoTimesAnti() { //2X Multi Sampling
        QualitySettings.antiAliasing = 2;
    }

    public void fourTimesAnti() { //4X Multi Sampling
        QualitySettings.antiAliasing = 4;
    }

    public void eightTimesAnti() { //8X Multi Sampling
        QualitySettings.antiAliasing = 8;
    }
}
