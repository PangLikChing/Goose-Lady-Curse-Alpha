using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is a temporary implementation
public class MainMenu : Menu
{
    public MenuClassifier pauseMenu;
    public MenuClassifier hudMenu;
    public string playerDataScene;
    public InputReader inputReader;
    private List<string> sceneToBeLoaded = new List<string>();

    private void OnEnable()
    {
        inputReader.EnableMenuInput();
    }

    public void LoadGameScene(string sceneName)
    {
        sceneToBeLoaded.Add(playerDataScene);
        sceneToBeLoaded.Add(sceneName);
        SceneLoader.Instance.OnSceneLoadedEvent += OnGameSceneLoaded;
        SceneLoader.Instance.LoadScenes(sceneToBeLoaded);
        this.OnHideMenu();
        MenuManager.Instance.GetMenu<PauseMenu>(pauseMenu).currentGameScene = sceneName;
        
    }

    public void OnGameSceneLoaded(List<string> scenes)
    {
        SceneLoader.Instance.OnSceneLoadedEvent -= OnGameSceneLoaded;
        sceneToBeLoaded.Clear();
        MenuManager.Instance.ShowMenu(hudMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
