using UnityEngine;
public class Modifier:ScriptableObject
{
    
    public float magnitude;
    public float remainingTime;
    public bool isPersistent = false;

    public virtual void Apply() { }
    public virtual void Remove() { }
}
