using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    public MenuClassifier mainMenu;
    public string currentGameScene;
    public void ReturnToMainMenu()
    {
        OnHideMenu();
        MenuManager.Instance.ShowMenu(mainMenu);
        SceneLoader.Instance.UnloadScene(currentGameScene);
    }

    public void Resume()
    {
        OnHideMenu();
    }

    public override void OnShowMenu(string options = "")
    {
        Time.timeScale = 0;//temporary pause implementation
        base.OnShowMenu(options);
    }

    public override void OnHideMenu(string options = "")
    {
        Time.timeScale = 1;
        base.OnHideMenu(options);
    }
}
