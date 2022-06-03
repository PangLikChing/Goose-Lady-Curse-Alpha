using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public Action<List<string>> OnSceneLoadedEvent = delegate { };
    public Action OnSceneUnloadedEvent = delegate { };
    public string currentActiveScene;
    public float delayTime = 1.0f;
    private List<string> loadedScenes = new List<string>();
    private Stack<string> sceneStack = new Stack<string>();

    private void OnEnable()
    {
        sceneStack.Push(SceneManager.GetActiveScene().path);
    }

    private void OnDisable()
    {
        sceneStack.Pop();
    }

    // When loading just add a flag for persistence. If true don't add to the loadedScenes
    // Only remove the scenes when you unload
    public void LoadScene(string scene, bool showLoadingScreen = true)
    {
        StartCoroutine(loadScene(scene, showLoadingScreen, true));
    }

    public void LoadScenes(List<string> scenes, bool showLoadingScreen = true)
    {
        StartCoroutine(loadScenes(scenes, showLoadingScreen));
    }

    IEnumerator loadScenes(List<string> scenes, bool showLoadingScreen)
    {
        if (showLoadingScreen)
        {
            MenuManager.Instance.ShowMenu(MenuManager.Instance.LoadingScreen);
        }

        foreach (string scene in scenes)
        {
            yield return StartCoroutine(loadScene(scene, false, false));
        }

        if (showLoadingScreen)
        {
            MenuManager.Instance.HideMenu(MenuManager.Instance.LoadingScreen);
        }

        if (OnSceneLoadedEvent != null)
        {
            loadedScenes.Clear();
            loadedScenes.AddRange(scenes);
            OnSceneLoadedEvent(loadedScenes);

        }
        SetCurrentSceneActive();
    }

    IEnumerator loadScene(string scene, bool showLoadingScreen, bool raiseEvent)
    {
        if (SceneManager.GetSceneByPath(scene).isLoaded == false)
        {
            if (showLoadingScreen)
            {
                MenuManager.Instance.ShowMenu(MenuManager.Instance.LoadingScreen);
            }

            yield return new WaitForSeconds(delayTime);

            AsyncOperation sync;

            Application.backgroundLoadingPriority = ThreadPriority.Low;

            sync = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            while (sync.isDone == false) { yield return null; }

            Application.backgroundLoadingPriority = ThreadPriority.Normal;
            sceneStack.Push(scene);

            yield return new WaitForSeconds(delayTime);

            if (showLoadingScreen)
            {
                MenuManager.Instance.HideMenu(MenuManager.Instance.LoadingScreen);
            }
        }

        if (raiseEvent && OnSceneLoadedEvent != null)
        {
            loadedScenes.Clear();
            loadedScenes.Add(scene);
            OnSceneLoadedEvent(loadedScenes);

        }
        SetCurrentSceneActive();
    }

    // 4 Methods:
    //	- Unload single scene
    //	- Unload list of scenes
    //		- Support to unload multiple (Coroutine)
    //	- Actual Unload of scenes.

    public void UnloadScene(string scene, bool showLoadingScreen = true)
    {
        StartCoroutine(unloadScene(scene, showLoadingScreen, true));
    }

    public void UnloadScenes(List<string> scenes, bool showLoadingScreen = true)
    {
        StartCoroutine(unloadScenes(scenes, showLoadingScreen));
    }

    IEnumerator unloadScenes(List<string> scenes, bool showLoadingScreen)
    {
        if (showLoadingScreen)
        {
            MenuManager.Instance.ShowMenu(MenuManager.Instance.LoadingScreen);
        }
        foreach (string scene in scenes)
        {
            yield return StartCoroutine(unloadScene(scene, false, false));
        }
        if (showLoadingScreen)
        {
            MenuManager.Instance.HideMenu(MenuManager.Instance.LoadingScreen);
        }
        if (OnSceneUnloadedEvent != null)
        {
            OnSceneUnloadedEvent();
        }
        SetCurrentSceneActive();
    }

    IEnumerator unloadScene(string scene, bool showLoadingScreen, bool raiseEvent)
    {
        if (showLoadingScreen)
        {
            MenuManager.Instance.ShowMenu(MenuManager.Instance.LoadingScreen);
        }

        yield return new WaitForSeconds(delayTime);

        AsyncOperation sync = null;

        try
        {
            sync = SceneManager.UnloadSceneAsync(scene);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        if (sync != null)
        {
            while (sync.isDone == false) { yield return null; }
        }

        sync = Resources.UnloadUnusedAssets();
        while (sync.isDone == false) { yield return null; }

        sceneStack.Pop();

        yield return new WaitForSeconds(delayTime);

        if (showLoadingScreen)
        {
            MenuManager.Instance.HideMenu(MenuManager.Instance.LoadingScreen);
        }

        if (raiseEvent && OnSceneUnloadedEvent != null)
        {
            OnSceneUnloadedEvent();

        }
        SetCurrentSceneActive();
    }

    private void SetCurrentSceneActive()
    {
        Scene topScene = SceneManager.GetSceneByPath(sceneStack.Peek());
        if (topScene.IsValid())
            SceneManager.SetActiveScene(topScene);
        currentActiveScene = sceneStack.Peek();
    }
}
