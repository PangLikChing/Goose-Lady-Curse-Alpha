using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotebookHotkeyHandler : MonoBehaviour
{
    public InputReader reader;
    public UnityEvent ToggleNotebook;
    private void OnEnable()
    {
        reader.OpenNoteBookEvent += ToggleNotebookUI;
    }

    private void OnDisable()
    {
        reader.OpenInventoryEvent -= ToggleNotebookUI;
    }

    private void ToggleNotebookUI()
    {
        ToggleNotebook.Invoke();
    }
}
