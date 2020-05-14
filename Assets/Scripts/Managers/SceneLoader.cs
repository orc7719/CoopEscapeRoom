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

    string currentScene = "";
    string newActiveScene = "";
    bool isLoading = false;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadGameScene(int roleToLoad, int sceneToLoad)
    {
        string sceneName = roleToLoad == 0 ? commanderScene : survivorScenes[sceneToLoad];
        StartCoroutine("ChangeGameScene", sceneName);
    }

    public void LoadGameScene(string sceneToLoad)
    {
        StartCoroutine("ChangeGameScene", sceneToLoad);
    }

    IEnumerator ChangeGameScene(string newScene)
    {
        if (isLoading)
            yield break;

        isLoading = true;

        //Fade to black

        //Unload current scene
        if(currentScene != "")
        {
            AsyncOperation unloadAsync = SceneManager.UnloadSceneAsync(currentScene);

            yield return unloadAsync;
        }

        //Load new scene
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        loadAsync.allowSceneActivation = false;
        newActiveScene = SceneManager.GetSceneByPath(newScene).name;

        while (!loadAsync.isDone)
        {
            if(loadAsync.progress >= 0.9f)
            {
                loadAsync.allowSceneActivation = true;
                
            }
            yield return null;
        }

        currentScene = newScene;

        //Fade from black
        isLoading = false;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (newActiveScene == "")
            return;

        if (SceneManager.GetSceneByName(newActiveScene).name == scene.name)
        {
            SceneManager.SetActiveScene(scene);
        }

        newActiveScene = "";
    }
}