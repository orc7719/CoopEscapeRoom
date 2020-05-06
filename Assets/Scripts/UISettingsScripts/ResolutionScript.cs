using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class ResolutionScript : MonoBehaviour
{

    [Header("currentScreen Resolution"), SerializeField] private int screenHeight, ScreenWidth;

    bool fullScreen;

    public TMP_Dropdown dropDown;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.currentResolution.height;

        ScreenWidth = Screen.currentResolution.width;

        fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("" + Screen.currentResolution);

        if (dropDown.value == 0) {
            auto();
        }

        if (dropDown.value == 1) {
            twentyOneSixtyP();
        }

        if (dropDown.value == 2) {
            eighteenHundredP();
        }

        if (dropDown.value == 3) {
            fourteenFourtyP();
        }

        if (dropDown.value == 4) {
            tenEightyP();
        }

        if (dropDown.value == 5) {
            tenfiftyP();
        }

        if (dropDown.value == 6) {
            nineHundred();
        }

        if (dropDown.value == 7) {
            tenTwentyFour();
        }

        if (dropDown.value == 8) {
            sevenTwentyP();
        }

        if (dropDown.value == 9) {
            sevenSixEight();
        }

        if (dropDown.value == 10) {
            Sixhundred();
        }
    }

    public void twentyOneSixtyP() { //3840 x 2160 or 4K == value 1
        Screen.SetResolution(3840, 2160, fullScreen);
    }

    public void eighteenHundredP() { //3200 x 1800 == value 2
        Screen.SetResolution(3200, 1800, fullScreen);
    }

    public void fourteenFourtyP() { //2560 x 1440 or 2K == value 3
        Screen.SetResolution(2560, 1440, fullScreen);
    }

    public void tenEightyP() { //1920 x 1080 or Full HD == value 4
        Screen.SetResolution(1920, 1080, fullScreen);
    }

    public void tenfiftyP() { //1680 x 1050 == value 5
        Screen.SetResolution(1680, 1050, fullScreen);
    }

    public void nineHundred() { //1600 x 900 == value 6
        Screen.SetResolution(1600, 900, fullScreen);
    }

    public void tenTwentyFour() { //1280 x 1024 == value 7
        Screen.SetResolution(1280, 1024, fullScreen);
    }

    public void sevenTwentyP() { //1280 x 720 or Standard HD == value 8
        Screen.SetResolution(1280, 720, fullScreen);
    }

    public void sevenSixEight() { //1024 x 768 == value 9
        Screen.SetResolution(1024, 768, fullScreen);
    }

    public void Sixhundred() { //800 x 600 == value 10
        Screen.SetResolution(800, 600, fullScreen);

        
    }

    public void auto() {  // value 0
        Screen.SetResolution(ScreenWidth, screenHeight, fullScreen);
    }

}
