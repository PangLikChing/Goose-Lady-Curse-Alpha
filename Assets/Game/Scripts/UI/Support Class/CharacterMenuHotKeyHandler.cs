using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuHotKeyHandler : MonoBehaviour
{
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;
    public MenuClassifier characterMenu;
    private void OnEnable()
    {
        inputReader.OpenCharacterPanelEvent += OpenCharacterMenu;
    }

    private void OnDisable()
    {
        inputReader.OpenCharacterPanelEvent -= OpenCharacterMenu;
        inputReader.OpenCharacterPanelEvent -= CloseCharacterMenu;
    }

    public void OpenCharacterMenu()
    {
        MenuManager.Instance.GetMenu<CharacterMenu>(characterMenu).OnShowMenu();
        inputReader.OpenCharacterPanelEvent += CloseCharacterMenu;
        inputReader.OpenCharacterPanelEvent -= OpenCharacterMenu;
    }

    public void CloseCharacterMenu()
    {
        MenuManager.Instance.GetMenu<CharacterMenu>(characterMenu).OnHideMenu();
        inputReader.OpenCharacterPanelEvent += OpenCharacterMenu;
        inputReader.OpenCharacterPanelEvent -= CloseCharacterMenu;
    }
}
