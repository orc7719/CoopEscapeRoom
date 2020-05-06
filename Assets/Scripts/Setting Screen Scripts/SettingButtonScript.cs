using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingButtonScript : MonoBehaviour
{

    [Header("Buttons")] 
    public GameObject displayButton;
    public GameObject graphicsButton; 
    public GameObject audioButton;
    public GameObject controlsButton;

    [Header("Screens")] 
    public GameObject displayScreen; 
    public GameObject graphicsScreen; 
    public GameObject audioScreen; 
    public GameObject controlsScreen;

    [Header("Button Text")]
    public TMP_Text displayTxt;

    public TMP_Text graphicsTxt;

    public TMP_Text audioTxt;

    public TMP_Text controlsTxt;
    // Start is called before the first frame update
    void Start()
    {
        displayScreen.SetActive(true);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (displayScreen.activeInHierarchy == true) {
            displayTxt.fontStyle = FontStyles.Bold;
        }
        else {
            displayTxt.fontStyle = FontStyles.Normal;
        }

        if (graphicsScreen.activeInHierarchy == true) {
            graphicsTxt.fontStyle = FontStyles.Bold;
        }
        else {
            graphicsTxt.fontStyle = FontStyles.Normal;
        }

        if (audioScreen.activeInHierarchy == true) {
            audioTxt.fontStyle = FontStyles.Bold;
        }
        else {
            audioTxt.fontStyle = FontStyles.Normal;
        }

        if (controlsScreen.activeInHierarchy == true) {
            controlsTxt.fontStyle = FontStyles.Bold;
        }
        else {
            controlsTxt.fontStyle = FontStyles.Normal;
        }

    }

    public void displayButtonPressed() {
        displayScreen.SetActive(true);
        graphicsScreen.SetActive(false);
        audioScreen.SetActive(false);
        controlsScreen.SetActive(false);

        
    }

    public void graphicsButtonPressed() {
        displayScreen.SetActive(false);
        graphicsScreen.SetActive(true);
        audioScreen.SetActive(false);
        controlsScreen.SetActive(false);

      
    }

    public void audioButtonPressed() {
        displayScreen.SetActive(false);
        graphicsScreen.SetActive(false);
        audioScreen.SetActive(true);
        controlsScreen.SetActive(false);


    }

    public void controlsButtonPressed() {
        displayScreen.SetActive(false);
        graphicsScreen.SetActive(false);
        audioScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }
}
