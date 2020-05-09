using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [Scene]
    public string commanderScene;

    [Scene]
    public string[] survivorScenes;

    public void LoadGameScene(int roleToLoad, int sceneToLoad)
    {
        string sceneName = roleToLoad == 0 ? commanderScene : survivorScenes[sceneToLoad];
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
