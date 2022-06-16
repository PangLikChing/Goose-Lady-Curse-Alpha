using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// A scriptable object that can be attached to any class that need input
/// </summary>
[CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, InputMap.ICharacterControlsActions, InputMap.IGameplayMenusActions, InputMap.ISystemMenusActions, InputMap.IDialoguesActions
{
    public event UnityAction<Vector3> MovementEvent = delegate { };
    public event UnityAction<Transform> AttackEvent = delegate { };
    public event UnityAction<Transform> PickupEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction<float> ZoomEvent = delegate { };
    public event UnityAction OpenInventoryEvent = delegate { };
    public event UnityAction OpenCharacterPanelEvent = delegate { };
    public event UnityAction OpenCraftingMenuEvent = delegate { };
    public event UnityAction OpenHelpMenuEvent = delegate { };
    public event UnityAction OpenPauseMenuEvent = delegate { };
    public event UnityAction ClosePauseMenuEvent = delegate { };
    public event UnityAction OpenBuildMenuEvent = delegate { };
    public event UnityAction CloseAllMenusEvent = delegate { };

    private InputMap gameInput;
    private Ray ray;
    private RaycastHit hit;
    private LayerMask TerrainLayerMask;
    private LayerMask AttackableLayerMask;
    private LayerMask ItemLayerMask;
    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new InputMap();
            gameInput.CharacterControls.SetCallbacks(this);
            gameInput.GameplayMenus.SetCallbacks(this);
            gameInput.SystemMenus.SetCallbacks(this);
            gameInput.Dialogues.SetCallbacks(this);
        }
        TerrainLayerMask = LayerMask.GetMask("Terrain");
        AttackableLayerMask = LayerMask.GetMask("Attackable");
        ItemLayerMask = LayerMask.GetMask("Item");
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
        //dont click through UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (context.phase == InputActionPhase.Performed && Physics.Raycast(ray, out hit, 500f, TerrainLayerMask))
        {
            MovementEvent.Invoke(hit.point);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //dont click through UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (context.phase == InputActionPhase.Performed && Physics.Raycast(ray, out hit, 500f, AttackableLayerMask))
        {
            AttackEvent.Invoke(hit.collider.transform);

        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        //dont click through UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (context.phase == InputActionPhase.Performed && Physics.Raycast(ray, out hit, 500f, ItemLayerMask))
        {
            PickupEvent.Invoke(hit.collider.transform);

        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            InteractEvent.Invoke();
        }
    }

    public void OnZoomCamera(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ZoomEvent.Invoke(context.ReadValue<float>());
        }
    }

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenInventoryEvent.Invoke();
        }
    }

    public void OnOpenCharacterPanel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenCharacterPanelEvent.Invoke();
        }
    }

    public void OnOpenCraftingMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenCraftingMenuEvent.Invoke();
        }
    }

    public void OnOpenHelpMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenHelpMenuEvent.Invoke();
        }
    }

    public void OnOpenPauseMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenPauseMenuEvent.Invoke();
        }
    }

    public void OnClosePauseMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ClosePauseMenuEvent.Invoke();
        }
    }

    public void OnOpenBuildMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenBuildMenuEvent.Invoke();
        }
    }

    public void OnCloseAllMenus(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            CloseAllMenusEvent.Invoke();
        }
    }

    public void EnableGameplayInput()
    {
        gameInput.CharacterControls.Enable();
        gameInput.GameplayMenus.Enable();
        gameInput.SystemMenus.Disable();
    }

    public void EnableSystemMenuInput()
    {
        gameInput.SystemMenus.Enable();
        gameInput.CharacterControls.Disable();
        gameInput.GameplayMenus.Disable();
    }

    public void EnableCharacterControl()
    {
        gameInput.CharacterControls.Enable();
    }

    public void DisableCharacterControl()
    {
        gameInput.CharacterControls.Disable();
    }

    public void DisableAllInput()
    {
        gameInput.SystemMenus.Disable();
        gameInput.CharacterControls.Disable();
        gameInput.GameplayMenus.Disable();
    }
}
