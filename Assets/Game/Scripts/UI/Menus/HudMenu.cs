using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudMenu : Menu
{
    public MenuClassifier pauseMenu;
    
    public void OpenPauseMenu()
    {
        Time.timeScale = 0;//temporary pause implementation
        MenuManager.Instance.ShowMenu(pauseMenu);
    }
}
