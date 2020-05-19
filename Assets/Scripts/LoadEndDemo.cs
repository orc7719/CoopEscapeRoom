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
        SceneManager.LoadScene(demoEndScene);
    }
}
