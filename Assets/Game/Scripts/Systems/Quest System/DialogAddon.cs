using UnityEngine;
using UnityEngine.Events;

public class DialogAddon : MonoBehaviour
{
    public InputReader inputReader;
    public UnityEvent<bool> DialogEnabled;
    private void OnEnable()
    {
        inputReader.EnableDialogInput();
        DialogEnabled.Invoke(false);//disable HUD
    }

    private void OnDisable()
    {
        inputReader.EnableGameplayInput();
        DialogEnabled.Invoke(true);//enable HUD
    }
}
