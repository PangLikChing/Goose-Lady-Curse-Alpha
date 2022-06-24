using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// The hud menu controller
/// </summary>
public class HudMenu : Menu
{
    [Tooltip("Reference to pause menu")]
    public MenuClassifier pauseMenu;
    [Tooltip("Reference to input reader")]
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

    /// <summary>
    /// Callback for open pause menu button
    /// </summary>
    public void OpenPauseMenu()
    {
        MenuManager.Instance.ShowMenu(pauseMenu);
        this.OnHideMenu();
    }
}
