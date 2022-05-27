using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    public MenuClassifier mainMenu;
    public MenuClassifier hudMenu;
    public string currentGameScene;
    public string gamePlayScene;
    public InputReader inputReader;

    private List<string> sceneToBeUnloaded = new List<string>();

    private void OnEnable()
    {
        inputReader.EnableMenuInput();
        inputReader.ClosePauseMenuEvent += Resume;
    }

    private void OnDisable()
    {
        //inputReader.DisableAllInput();
        inputReader.ClosePauseMenuEvent -= Resume;
    }

    public void ReturnToMainMenu()
    {
        OnHideMenu();
        sceneToBeUnloaded.Add(gamePlayScene);
        sceneToBeUnloaded.Add(currentGameScene);
        SceneLoader.Instance.OnSceneUnloadedEvent += OnReturnToMainMenu;
        SceneLoader.Instance.UnloadScenes(sceneToBeUnloaded);
    }

    public void OnReturnToMainMenu()
    {
        sceneToBeUnloaded.Clear();
        SceneLoader.Instance.OnSceneUnloadedEvent -= OnReturnToMainMenu;
        MenuManager.Instance.ShowMenu(mainMenu);
    }

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
