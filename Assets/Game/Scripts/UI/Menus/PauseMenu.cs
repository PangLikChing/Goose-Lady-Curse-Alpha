using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    [Tooltip("Reference to main menu")]
    public MenuClassifier mainMenu;
    [Tooltip("Reference to hud menu")]
    public MenuClassifier hudMenu;
    [Tooltip("Reference to the scene that storges gameplay persistance data")]
    public SceneReference gameplayGlobalScene;
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;

    private List<string> sceneToBeUnloaded = new List<string>();
    private void OnEnable()
    {
        inputReader.EnableSystemMenuInput();
        inputReader.ClosePauseMenuEvent += Resume;
    }

    private void OnDisable()
    {
        //inputReader.DisableAllInput();
        inputReader.ClosePauseMenuEvent -= Resume;
    }

    /// <summary>
    /// Callback that return the to the main menu, unloads player data and current gameplay scene
    /// </summary>
    public void ReturnToMainMenu()
    {
        OnHideMenu();
        sceneToBeUnloaded.Add(gameplayGlobalScene.ScenePath);
        sceneToBeUnloaded.Add(SceneLoader.Instance.currentActiveScene);
        SceneLoader.Instance.OnSceneUnloadedEvent += OnReturnToMainMenu;
        SceneLoader.Instance.UnloadScenes(sceneToBeUnloaded);
    }

    /// <summary>
    /// Callback for show main menu
    /// </summary>
    public void OnReturnToMainMenu()
    {
        sceneToBeUnloaded.Clear();
        SceneLoader.Instance.OnSceneUnloadedEvent -= OnReturnToMainMenu;
        MenuManager.Instance.ShowMenu(mainMenu);
    }

    /// <summary>
    /// Unpause and return to game
    /// </summary>
    public void Resume()
    {
        OnHideMenu();
        MenuManager.Instance.ShowMenu(hudMenu);
    }

    public override void OnShowMenu(string options = "")
    {
        Time.timeScale = 0;
        base.OnShowMenu(options);
    }

    public override void OnHideMenu(string options = "")
    {
        Time.timeScale = 1;
        base.OnHideMenu(options);
    }
}
