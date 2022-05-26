using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public event UnityAction<Vector3> MovementEvent = delegate { };
    public event UnityAction<GameObject> AttackEvent = delegate { };
    public event UnityAction<GameObject> PickupEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction<float> ZoomEvent = delegate { };
    public event UnityAction OpenInventoryEvent = delegate { };
    public event UnityAction OpenCharacterPanelEvent = delegate { };
    public event UnityAction OpenCraftingMenuEvent = delegate { };
    public event UnityAction OpenHelpMenuEvent = delegate { };
    public event UnityAction OpenPauseMenuEvent = delegate { };
    public event UnityAction ClosePauseMenuEvent = delegate { };
    public event UnityAction OpenBuildMenuEvent = delegate { };

    private Ray ray;
    private RaycastHit hit;
    private LayerMask TerrainLayerMask;
    private LayerMask AttackableLayerMask;
    private LayerMask ItemLayerMask;
    private void OnEnable()
    {
        TerrainLayerMask = LayerMask.GetMask("Terrain");
        AttackableLayerMask = LayerMask.GetMask("Attackable");
        ItemLayerMask = LayerMask.GetMask("Item");
    }

    public void OnMovements()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 500f, TerrainLayerMask))
        {
            MovementEvent.Invoke(hit.point);
        }
    }

    public void OnAttack()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 500f, AttackableLayerMask))
        {
            AttackEvent.Invoke(hit.collider.gameObject);
        }
    }

    public void OnPickup()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 500f, ItemLayerMask))
        {
            PickupEvent.Invoke(hit.collider.gameObject);
        }
    }

    public void OnInteract()
    {
        InteractEvent.Invoke();
    }

    public void OnZoomCamera(InputValue value)
    {
        ZoomEvent.Invoke(value.Get<float>());
    }

    public void OnOpenInventory()
    {
        OpenInventoryEvent.Invoke();
    }

    public void OnOpenCharacterPanel()
    {
        OpenCharacterPanelEvent.Invoke();
    }

    public void OnOpenCraftingMenu()
    {
        OpenCraftingMenuEvent.Invoke();
    }

    public void OnOpenHelpMenu()
    {
        OpenHelpMenuEvent.Invoke();
    }

    public void OnOpenPauseMenu()
    {
        OpenPauseMenuEvent.Invoke();
    }

    public void OnClosePauseMenu()
    {
        ClosePauseMenuEvent.Invoke();
    }

    public void OnOpenBuildMenu()
    {
        OpenBuildMenuEvent.Invoke();
    }

}
