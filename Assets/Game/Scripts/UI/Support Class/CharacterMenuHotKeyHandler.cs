using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenuHotKeyHandler : MonoBehaviour
{
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;
    public GameObject characterMenu;
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
        characterMenu.SetActive(true);
        inputReader.OpenCharacterPanelEvent += CloseCharacterMenu;
        inputReader.OpenCharacterPanelEvent -= OpenCharacterMenu;
    }

    public void CloseCharacterMenu()
    {
        characterMenu.SetActive(false);
        inputReader.OpenCharacterPanelEvent += OpenCharacterMenu;
        inputReader.OpenCharacterPanelEvent -= CloseCharacterMenu;
    }
}
