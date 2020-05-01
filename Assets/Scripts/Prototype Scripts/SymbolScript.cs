using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SymbolScript : MonoBehaviour
{

    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        if (gameObject.tag == "correctTile")
        {
            gameObject.SetActive(false);
        }
    }

    
}
