using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public SceneReference StartupScene;

    public bool ShowMainMenu = true;
    public MenuClassifier MainMenuClassifier;

    private void Start()
    {
        Scene scene = SceneManager.GetSceneByPath(StartupScene);
        if (scene.isLoaded == false)
        {
            StartCoroutine(BootSequence());
        }
        else if (scene.buildIndex == -1)
        {
            Debug.Assert(false, $"Scene no found {StartupScene}");
        }
        else
        {
            StartCoroutine(IgnoreBootSequence());
        }
    }

    IEnumerator IgnoreBootSequence()
    {
        yield return new WaitForSeconds(1);
        SceneLoadedCallback(null);
    }

    IEnumerator BootSequence()
    {
        yield return new WaitForSeconds(1);
        SceneLoader.Instance.OnSceneLoadedEvent += SceneLoadedCallback;
        SceneLoader.Instance.LoadScene(StartupScene, false);
    }

    void SceneLoadedCallback(List<string> scenesLoaded)
    {
        SceneLoader.Instance.OnSceneLoadedEvent -= SceneLoadedCallback;
        MenuManager.Instance.HideMenu(MenuManager.Instance.LoadingScreen);

#if UNITY_EDITOR
        if (ShowMainMenu)
        {
            MenuManager.Instance.ShowMenu(MainMenuClassifier);
        }
        else
        {
            MenuManager.Instance.HideMenu(MainMenuClassifier);
        }
#else
            MenuManager.Instance.ShowMenu(MainMenuClassifier);
#endif
    }
}
