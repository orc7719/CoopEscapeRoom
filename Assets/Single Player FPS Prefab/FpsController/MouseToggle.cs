using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToggle : MonoBehaviour
{
    public GameObject player;
    
    public Camera FPScamera;
    bool mouseActive;
    // Start is called before the first frame update
    void Start()
    {

        mouseActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            mouseActive = !mouseActive;
        }

        if (mouseActive == true) {
            Cursor.visible = true;

            player.transform.position = player.transform.position;

            FPScamera.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else {
            Cursor.visible = false;

            FPScamera.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
