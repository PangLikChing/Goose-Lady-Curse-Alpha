using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// This class is a library of actions the avatar can perform.
/// The controller will invoke methods from this class to perform an action
/// </summary>
public class AvatarActions : MonoBehaviour
{
    [Tooltip("Avatar can pickup item under this range")]
    public float pickUpRange = 1.5f;
    [Tooltip("Avatar can attack enemy under this range")]
    public float attackRange = 1.5f;
    [Tooltip("A margin to off the inaccuracy of avatar movement")]
    public float rangeMargin = 0.1f;
    [Tooltip("Refence to avatar motion  script")]
    public AvatarLocomotion motion;
    [Tooltip("This channel send item pickup event to inventory")]
    public UnityEvent<Item,int> ItemPickupEvent;
    private Animator avatarAnimator;

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
        avatarAnimator = GetComponent<Animator>();
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
        if (item.TryGetComponent<ItemWrapper>(out ItemWrapper itemWrapper))
        {
            ItemPickupEvent.Invoke(itemWrapper.item,1); //TODO: replace 1 with stack number from the item
            Destroy(item.gameObject,0.1f);
        }
    }

    public void CancelPickup()
    {
        //target = null;
    }

    public void DropOff()
    { 
    }

    /// <summary>
    /// Attack the enemy.
    /// Play the attack animation and deal damage
    /// </summary>
    /// <param name="enemy">Enemy</param>
    public void Attack(Transform enemy)
    {
        //Debug.Log($"Attack {enemy}");
        avatarAnimator.SetBool("attack", true);
    }

    public void CancelAttack()
    {
        avatarAnimator.SetBool("attack", false);
    }

    public void Interact()
    {
    }

    public void Die()
    {
        avatarAnimator.SetTrigger("die");
    }

    public void Spawn(Transform spawnPoint)
    {
        avatarAnimator.SetTrigger("spawn");
        transform.position = spawnPoint.position;
    }

    public void OpenCharacterPanel()
    {
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
