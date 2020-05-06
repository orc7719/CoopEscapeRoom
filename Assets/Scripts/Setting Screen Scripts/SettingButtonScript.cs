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
        displayTxt = GetComponent<TMP_Text>();
        graphicsTxt = GetComponent<TMP_Text>();
        audioTxt = GetComponent<TMP_Text>();
        controlsTxt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (displayScreen.activeInHierarchy == true) {
            displayTxt.fontStyle = FontStyle.Bold;
        }
        else {
            displayTxt.fontStyle = FontStyle.Normal;
        }

        if (graphicsScreen.activeInHierarchy == true) {
            graphicsTxt.fontStyle = FontStyle.Bold;
        }
        else {
            graphicsTxt.fontStyle = FontStyle.Normal;
        }

        if (audioScreen.activeInHierarchy == true) {
            audioTxt.fontStyle = FontStyle.Bold;
        }
        else {
            audioTxt.fontStyle = FontStyle.Normal;
        }

        if (controlsScreen.activeInHierarchy == true) {
            controlsTxt.fontStyle = FontStyle.Bold;
        }
        else {
            controlsTxt.fontStyle = FontStyle.Normal;
        }

    }

    public void displayButtonPressed() {
        displayScreen.SetActive(true);
        graphicsScreen.SetActive(false);
        audioScreen.SetActive(false);
        controlsScreen.SetActive(false);

        Debug.Log("display");
    }

    public void graphicsButtonPressed() {
        displayScreen.SetActive(false);
        graphicsScreen.SetActive(true);
        audioScreen.SetActive(false);
        controlsScreen.SetActive(false);

        Debug.Log("graphics");
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
