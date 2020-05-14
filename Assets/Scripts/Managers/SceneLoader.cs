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
        Debug.Log("Load");
        StartCoroutine("ChangeGameScene", sceneToLoad);
    }

    IEnumerator ChangeGameScene(string newScene)
    {
        Debug.Log("Starting Load");

        if (isLoading)
            yield break;

        isLoading = true;

        currentScene = SceneManager.GetActiveScene().name;

        //Fade to black

        //Unload current scene
        if(currentScene != "")
        {
            AsyncOperation unloadAsync = SceneManager.UnloadSceneAsync(currentScene);

            while (!unloadAsync.isDone)
            {
                yield return null;
            }
        }

        //Load new scene
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        loadAsync.allowSceneActivation = false;
        newActiveScene = "";

        while (!loadAsync.isDone)
        {
            if(loadAsync.progress >= 0.9f)
            {
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }

        //Fade from black
        isLoading = false;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name + ", Index: " + scene.buildIndex);

        if (newActiveScene == "")
            return;

        Debug.Log("Is active scene");

        Debug.Log("New Active Scene: " + newActiveScene + ", Loaded Scene: " + scene);

        if (SceneManager.GetSceneByName(newActiveScene) == scene)
        {
            Debug.Log("Setting active scene");
            SceneManager.SetActiveScene(scene);
        }

        newActiveScene = "";
    }
}