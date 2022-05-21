using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
	public Action<List<string>> OnSceneLoadedEvent;

	public float delayTime = 1.0f;
    private List<string> loadedScenes = new List<string>();

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

        loadedScenes.Clear();
        loadedScenes.AddRange(scenes);
        OnSceneLoadedEvent(loadedScenes);
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

            yield return new WaitForSeconds(delayTime);

            if (showLoadingScreen)
            {
                MenuManager.Instance.HideMenu(MenuManager.Instance.LoadingScreen);
            }
        }

        if (raiseEvent)
        {
            loadedScenes.Clear();
            loadedScenes.Add(scene);
            OnSceneLoadedEvent(loadedScenes);
        }
    }

    // 4 Methods:
    //	- Unload single scene
    //	- Unload list of scenes
    //		- Support to unload multiple (Coroutine)
    //	- Actual Unload of scenes.

    public void UnloadScene(string scene)
    {
        StartCoroutine(unloadScene(scene));
    }

    public void UnloadScenes(List<string> scenes)
    {
        StartCoroutine(unloadScenes(scenes));
    }

    IEnumerator unloadScenes(List<string> scenes)
    {
        foreach (string scene in scenes)
        {
            yield return StartCoroutine(unloadScene(scene));
        }
    }

    IEnumerator unloadScene(string scene)
    {
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
    }
}
