using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    public GameObject avatar;
    [HideInInspector]
    public UnityEvent MoveCmd;
    [HideInInspector]
    public UnityEvent<float> ZoomCameraCmd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //callback for movement action
    public void OnMovements() 
    {
        Debug.Log("click");
        MoveCmd.Invoke();
    }

    //callback for attack action
    public void OnAttack()
    { 
    }

    //callback for pickup action
    public void OnPickup()
    { 
    }

    //callback for interactions (mostly structures)
    public void OnInteract()
    { 
    }

    //callback for open inventory action
    public void OnOpenInventory()
    { 
    }


    //callback for open character panel action
    public void OnCharacterPanel()
    { 
    }

    //callback for open crating menu action
    public void OnOpenCraftingMenu()
    { 
    }

    //callback for open help menu action
    public void OnOpenHelpMenu()
    { 
    }

    //callback for open build menu
    public void OnOpenBuildMenu()
    { 
    }

    //callback for zoom camera action
    public void OnZoomCamera(InputValue value)
    {
        ZoomCameraCmd.Invoke(value.Get<float>());
    }
}
