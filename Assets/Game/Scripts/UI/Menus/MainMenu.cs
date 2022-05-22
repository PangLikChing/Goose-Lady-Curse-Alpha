using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is a temporary implementation
public class MainMenu : Menu
{
    public MenuClassifier pauseMenu;
    public MenuClassifier hudMenu;
    public void LoadScene(string sceneName)
    {
        SceneLoader.Instance.LoadScene(sceneName);
        this.OnHideMenu();
        MenuManager.Instance.GetMenu<PauseMenu>(pauseMenu).currentGameScene = sceneName;
        MenuManager.Instance.ShowMenu(hudMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
