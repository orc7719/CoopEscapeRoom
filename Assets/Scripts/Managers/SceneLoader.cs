using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [Header("Base Scenes")]
    [Scene]
    public string menuScene;

    [Scene]
    public string lobbyScene;

    [Header("Game Scenes")]
    [Scene]
    public string commanderScene;

    [Scene]
    public string[] survivorScenes;

    string currentScene = "";
    string newActiveScene = "";
    bool isLoading = false;

    BlurPanel blurPanel;

    protected override void Awake()
    {
        base.Awake();

        blurPanel = GetComponentInChildren<BlurPanel>();
        blurPanel.StartBlur(0, 1, 0);
    }

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

        if (Player.localPlayer != null)
            Player.localPlayer.DisablePlayer();

        //Unload current scene
        if(currentScene != "")
        {
            //Fade to black
            blurPanel.StartBlur(0, 1, 1);
            yield return new WaitForSeconds(1.1f);

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
        blurPanel.StartBlur(1, 0, 1);
        yield return new WaitForSeconds(1.1f);

        isLoading = false;

        if (Player.localPlayer != null)
            Player.localPlayer.EnablePlayer();
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

    public void LoadScene(string newScene)
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
        //StartCoroutine("ChangeGameScene", menuScene);
    }
}