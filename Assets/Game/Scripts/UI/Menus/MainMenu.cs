using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Main menu controller
/// </summary>
public class MainMenu : Menu
{
    [Tooltip("Reference to pause menu")]
    public MenuClassifier pauseMenu;
    [Tooltip("Reference to hud menu")]
    public MenuClassifier hudMenu;
    [Tooltip("Reference to the scene that storges gameplay persistance data")]
    public SceneReference gameplayGlobalScene;
    [Tooltip("Reference to world scene in game")]
    public SceneReference gameWorldScene;
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;
    private List<string> sceneToBeLoaded = new List<string>();

    private void OnEnable()
    {
        inputReader.EnableSystemMenuInput();
    }
    /// <summary>
    /// Callback for start button, load the first gameplay scene, player data scene and hide main menu
    /// </summary>
    /// <param name="sceneName">The name of the first gameplay scene</param>
    public void LoadGameScene()
    {
        sceneToBeLoaded.Add(gameplayGlobalScene.ScenePath); //Stay uniform with  startup script
        sceneToBeLoaded.Add(gameWorldScene.ScenePath);
        SceneLoader.Instance.OnSceneLoadedEvent += OnGameSceneLoaded;
        SceneLoader.Instance.LoadScenes(sceneToBeLoaded);
        this.OnHideMenu();
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
