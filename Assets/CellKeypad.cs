using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class CellKeypad : MonoBehaviour
{
    [SerializeField] string correctPasscode = "0526";
    string inputCode = "";

    bool canInput = true;

    [SerializeField] RawImage[] symbolDisplays;
    [SerializeField] Texture[] symbols;

    [SerializeField] GameEvent outputEvent;

    private void Start()
    {
        inputCode = "";

        for (int i = 0; i < symbolDisplays.Length; i++)
        {
            symbolDisplays[i].color = Color.clear;
        }
    }

    public void InputCode(int newCode)
    {
        if (!canInput)
            return;

        symbolDisplays[inputCode.Length].color = Color.white;
        symbolDisplays[inputCode.Length].texture = symbols[newCode];

        inputCode += newCode;
        

        if(inputCode.Length >= 4)
        {
            if(inputCode == correctPasscode)
            {
                canInput = false;
                NetworkedEventManager.instance.TriggerEvent("Symbols_KeypadCorrect");
            }
            else
            {
                inputCode = "";
                for (int i = 0; i < symbolDisplays.Length; i++)
                {
                    symbolDisplays[i].color = Color.clear;
                }
            }
        }
    }
}
