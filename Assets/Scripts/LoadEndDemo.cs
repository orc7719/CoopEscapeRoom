using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class LoadEndDemo : MonoBehaviour
{

    [Scene]
    [SerializeField]string demoEndScene;

    public void LoadDemoEnd()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(demoEndScene);
    }
}
