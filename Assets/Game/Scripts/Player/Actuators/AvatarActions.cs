using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// This class is a library of actions the avatar can perform.
/// The controller will invoke methods from this class to perform an action
/// </summary>
[RequireComponent(typeof(AvatarLocomotion))]
[RequireComponent(typeof(AvatarCombat))]
[RequireComponent(typeof(Animator))]
public class AvatarActions : MonoBehaviour
{
    [Tooltip("Avatar can pickup item under this range")]
    public float pickUpRange = 1.5f;
    [Tooltip("Avatar will drop item at this distance in front of him")]
    public float dropOffRange = 2f;
    [Tooltip("Avatar will drop item at this height in front of him")]
    public float dropOffHeight = 1f;
    [Tooltip("Avatar can attack enemy under this range")]
    public float attackRange = 1.5f;
    [Tooltip("A margin to off the inaccuracy of avatar movement")]
    public float rangeMargin = 0.1f;

    public bool inventoryIsFull { get; set; }

    [Tooltip("Refence to avatar motion script")]
    public AvatarLocomotion motion;
    [Tooltip("Refence to avatar combat script")]
    public AvatarCombat combat;
    [Tooltip("Avatar's spawn location")]
    public Transform spawnPoint;
    [Tooltip("This channel send item pickup event to inventory")]
    public UnityEvent<Item, int> ItemPickupEvent;

    public Structure interactionTarget;
    private Animator avatarAnimator;
    private bool hasAnimator;
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    public void ResetState()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        hasAnimator = TryGetComponent<Animator>(out avatarAnimator);
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// Pickup the item
    /// Send the item to inventory via event channel
    /// </summary>
    /// <param name="item">Item.</param>
    public void PickUp(Transform item)
    {
        if (item == null)
        {
            Debug.LogError("item is null");
            return;
        }
        if (item.TryGetComponent<ItemWrapper>(out ItemWrapper itemWrapper)&&!inventoryIsFull)
        {
            ItemPickupEvent.Invoke(itemWrapper.item, itemWrapper.stackNumber);
            Destroy(item.gameObject, 0.1f);
        }
        else
        {
            Debug.LogWarning("ItemWrapper is null");
            return;
        }
    }

    public void CancelPickup()
    {
        //target = null;
    }

    public void DropOff(Item item, int stack)
    {
        if (item == null)
        {
            Debug.LogError("item is null");
            return;
        }
        Transform itemPrefab = item.item3DModelPrefeb;
        if (itemPrefab == null)
        {
            Debug.LogError("itemPrefab is null");
            return;
        }
        GameObject spawnedItem = Instantiate(itemPrefab.gameObject, transform.position + transform.forward * dropOffRange + transform.up * dropOffHeight, transform.rotation);
        if (!spawnedItem.TryGetComponent<ItemWrapper>(out ItemWrapper itemWrapper))
        {
            Debug.LogWarning("ItemWrapper is null");
            return;
        }
        itemWrapper.stackNumber = stack;
        // Safety measure
        itemWrapper.item = item;

    }

    /// <summary>
    /// Attack the enemy.
    /// Play the attack animation and deal damage
    /// </summary>
    /// <param name="enemy">Enemy</param>
    public void Attack(Transform enemy)
    {
        combat.AttackTarget(enemy);
    }

    public void CancelAttack()
    {
        combat.AttackComplete();
    }

    public void Interact()
    {
        if (interactionTarget != null)
        {
            interactionTarget.Interact();
        }
    }

    public void Die()
    {
        if (hasAnimator)
        {
            avatarAnimator.SetTrigger("die");
        }
    }

    public void Spawn()
    {
        if (hasAnimator)
        {
            avatarAnimator.SetTrigger("spawn");
            motion.Warp(spawnPoint.position);
        }
    }

    public bool IsInPickupRange()
    {
        return motion.IsInInteractionRange(pickUpRange + rangeMargin);
    }

    public bool IsInAttackRange()
    {
        return motion.IsInInteractionRange(attackRange + rangeMargin);
    }


}
