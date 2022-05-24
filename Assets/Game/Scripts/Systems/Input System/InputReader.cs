using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]

public class InputReader : ScriptableObject, InputMap.IGameplayActions
{
    public event UnityAction MovementEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction PickupEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction<float> ZoomEvent = delegate { };
    public event UnityAction OpenInventoryEvent = delegate { };
    public event UnityAction OpenCharacterPanelEvent = delegate { };
    public event UnityAction OpenCraftingMenuEvent = delegate { };
    public event UnityAction OpenHelpMenuEvent = delegate { };
    public event UnityAction OpenPauseMenuEvent = delegate { };
    public event UnityAction OpenBuildMenuEvent = delegate { };

    private InputMap _gameInput;
    private Ray ray;
    private RaycastHit hit;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new InputMap();
            _gameInput.Gameplay.SetCallbacks(this);
        }
    }

    public void OnMovements(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            MovementEvent.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //TODO: raycast and check whos the target
        if (context.phase == InputActionPhase.Performed)
        {
            AttackEvent.Invoke();
        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        //TODO: raycast and check which item is it
        if (context.phase == InputActionPhase.Performed)
        {
            PickupEvent.Invoke();
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

    public void OnOpenBuildMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OpenBuildMenuEvent.Invoke();
        }
    }

}
