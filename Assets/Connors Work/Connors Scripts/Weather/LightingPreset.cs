using UnityEngine;

//Makes the menu option to create a scriptable object that holds the lightings settings
[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject
{
    //variable declaration
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;

}
