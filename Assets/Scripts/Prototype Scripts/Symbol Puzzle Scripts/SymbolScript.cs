using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SymbolScript : MonoBehaviour
{

    void OnMouseDown() {
        
    }

    public void correctTile() {
        if (gameObject.tag == "correctTile")
        {
            gameObject.SetActive(false);
        }
    }
    
}
