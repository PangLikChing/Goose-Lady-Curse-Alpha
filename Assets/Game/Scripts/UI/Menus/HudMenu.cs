using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudMenu : Menu
{
    public MenuClassifier pauseMenu;
    public InputReader inputReader;
    private void OnEnable()
    {
        inputReader.EnableGameplayInput();
        inputReader.OpenPauseMenuEvent += OpenPauseMenu;
    }

    private void OnDisable()
    {
        //inputReader.DisableAllInput();
        inputReader.OpenPauseMenuEvent -= OpenPauseMenu;
    }

    public void OpenPauseMenu()
    {
        MenuManager.Instance.ShowMenu(pauseMenu);
        this.OnHideMenu();
    }
}
