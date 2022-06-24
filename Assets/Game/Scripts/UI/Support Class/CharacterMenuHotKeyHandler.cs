using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMenuHotKeyHandler : MonoBehaviour
{
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;
    public UnityEvent ToggleCharacterMenu;
    private void OnEnable()
    {
        inputReader.OpenCharacterPanelEvent += ToggleCharacterMenuUI;
    }

    private void OnDisable()
    {
        inputReader.OpenCharacterPanelEvent -= ToggleCharacterMenuUI;
    }

    public void ToggleCharacterMenuUI()
    {
        ToggleCharacterMenu.Invoke();
    }
}
