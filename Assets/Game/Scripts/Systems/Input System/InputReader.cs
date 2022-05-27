using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]

public class InputReader : ScriptableObject, InputMap.IGameplayActions, InputMap.IMenusActions, InputMap.IDialoguesActions
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
            gameInput.Gameplay.SetCallbacks(this);
            gameInput.Menus.SetCallbacks(this);
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
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (context.phase == InputActionPhase.Performed && Physics.Raycast(ray, out hit, 500f, TerrainLayerMask))
        {
            MovementEvent.Invoke(hit.point);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (context.phase == InputActionPhase.Performed && Physics.Raycast(ray, out hit, 500f, AttackableLayerMask))
        {
            AttackEvent.Invoke(hit.collider.transform);
            
        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
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

    public void EnableGameplayInput()
    {
        gameInput.Gameplay.Enable();
        gameInput.Menus.Disable();
    }

    public void EnableMenuInput()
    {
        gameInput.Menus.Enable();
        gameInput.Gameplay.Disable();
    }

    public void DisableAllInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Menus.Disable();
    }
}
