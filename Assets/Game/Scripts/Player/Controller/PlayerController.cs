using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerController : Singleton<PlayerController>
{
    private Ray ray;
    private RaycastHit hit;

    public LayerMask movementLayerMask;
    [HideInInspector]
    public Camera mainCam;
    [HideInInspector]
    public UnityEvent<Vector3> MoveCmd;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //callback for movement action
    public void OnMovements() 
    {
        ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 500f, movementLayerMask))
        {
            MoveCmd.Invoke(hit.point);
        }
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
}
