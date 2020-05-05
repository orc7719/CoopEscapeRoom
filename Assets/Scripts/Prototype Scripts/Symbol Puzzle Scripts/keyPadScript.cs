using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyPadScript : MonoBehaviour
{

   [SerializeField] private string InputText;

   private string correctPasscode = "ACBD";

    [SerializeField] private TMP_Text passcodeTxt;

    public int numberKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        numberKeyPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if (numberKeyPressed == 4 && InputText == correctPasscode) {
           Debug.Log("Correct Passcode!!!");

           InputText = "Passcode Accepted";

           numberKeyPressed = 0;
       }
       else if (numberKeyPressed == 4 && InputText != correctPasscode) {
           InputText = "";

           numberKeyPressed = 0;
       }

       passcodeTxt.text = InputText;
    }

    public void OnePressed() {
        InputText = InputText + "A";
        numberKeyPressed++;

        Debug.Log("pressed");
    }

    public void TwoPressed() {
        InputText = InputText + "B";

        numberKeyPressed++;
    }

    public void ThreePressed() {
        InputText = InputText + "C";

        numberKeyPressed++;
    }

    public void FourPressed() {
        InputText = InputText + "D";

        numberKeyPressed++;
    }

    public void FivePressed() {
        InputText = InputText + "E";
    
        numberKeyPressed++;
    }

    public void SixPressed() {
        InputText = InputText + "F";

        numberKeyPressed++;
    }

    public void SevenPressed() {
        InputText = InputText + "G";

        numberKeyPressed++;
    }

    public void EightPressed() {
        InputText = InputText + "H";

        numberKeyPressed++;
    }

}
