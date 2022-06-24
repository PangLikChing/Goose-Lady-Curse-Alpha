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
        reader.OpenNoteBookEvent += ToggleNoteBook;
    }

    private void OnDisable()
    {
        reader.OpenInventoryEvent -= ToggleNoteBook;
    }

    private void ToggleNoteBook()
    {
        ToggleNotebook.Invoke();
    }
}
