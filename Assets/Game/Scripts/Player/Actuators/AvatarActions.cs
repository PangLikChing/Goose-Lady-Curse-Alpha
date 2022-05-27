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
    public float pickUpRange = 1.5f;
    public float attackRange = 1.5f;
    public float rangeMargin = 0.1f;
    public AvatarLocomotion motion;
    public ScriptableObjectEventChannel itemEventChannel;
    private Animator avatarAnimator;

    private void OnEnable()
    {

    }

    private void OnDisable()
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

    public void PickUp(Transform target)
    {
        Debug.Log($"Pick up {target}");
        //if (target.TryGetComponent<Item>(out Item item))
        //{
        //    itemEventChannel.Raise(item);
        //}
    }

    public void CancelPickup()
    {
        //target = null;
    }

    public void Attack(Transform target)
    {
        //Debug.Log($"Attack {target}");
        avatarAnimator.SetBool("attack", true);
    }

    public void CancelAttack()
    {
        avatarAnimator.SetBool("attack", false);
    }

    public void Interact()
    {
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
