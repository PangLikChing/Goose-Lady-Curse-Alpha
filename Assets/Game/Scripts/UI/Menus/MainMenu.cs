using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Main menu controller
/// </summary>
public class MainMenu : Menu
{
    [Tooltip("Reference to pause menu")]
    public MenuClassifier pauseMenu;
    [Tooltip("Reference to hud menu")]
    public MenuClassifier hudMenu;
    [Tooltip("Reference to the scene that storges player persistance data")]
    public string playerDataScene;
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;
    private List<string> sceneToBeLoaded = new List<string>();

    private void OnEnable()
    {
        inputReader.EnableMenuInput();
    }
    /// <summary>
    /// Callback for start button, load the first gameplay scene, player data scene and hide main menu
    /// </summary>
    /// <param name="sceneName">The name of the first gameplay scene</param>
    public void LoadGameScene(string sceneName)
    {
        sceneToBeLoaded.Add(playerDataScene);
        sceneToBeLoaded.Add(sceneName);
        SceneLoader.Instance.OnSceneLoadedEvent += OnGameSceneLoaded;
        SceneLoader.Instance.LoadScenes(sceneToBeLoaded);
        this.OnHideMenu();
        MenuManager.Instance.GetMenu<PauseMenu>(pauseMenu).currentGameScene = sceneName;
        
    }

    /// <summary>
    /// Callback for scene loaded event, and show hud menu
    /// </summary>
    /// <param name="scenes"></param>
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
