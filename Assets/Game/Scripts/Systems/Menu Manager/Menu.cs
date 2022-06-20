using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public abstract class Menu : MonoBehaviour
{
    public MenuClassifier menuClassifier;
    public RectTransform menuRoot;

    public enum StartingMenuStates
    {
        Ignore,
        Active,
        Disable
    };

    public StartingMenuStates startingMenuState;
    public bool resetPosition = true;

    public UnityEvent OnRefreshMenu = new UnityEvent();

    private Animator animator;
    public bool IsOpen
    {
        get
        {
            if (animator != null)
            {
                isOpen = animator.GetBool("IsOpen");
            }
            return isOpen;
        }

        set
        {
            isOpen = value;
            if (isOpen == true)
            {
                gameObject.SetActive(true);
            }

            if (animator != null)
            {
                animator.SetBool("IsOpen", isOpen);
            }
            else
            {
                gameObject.SetActive(isOpen);
            }

            if (value == true)
            {
                OnRefreshMenu.Invoke();
            }
        }
    }
    private bool isOpen = false;

    public virtual void OnShowMenu(string options = "")
    {
        IsOpen = true;
    }

    public virtual void OnHideMenu(string options = "")
    {
        IsOpen = false;
    }

    protected virtual void Awake()
    {
        if (resetPosition)
        {
            menuRoot = GetComponent<RectTransform>();
            menuRoot.localPosition = Vector3.zero;
        }
    }
    
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();

        MenuManager.Instance.AddMenu(this);

        switch(startingMenuState)
        {
            case StartingMenuStates.Active:
                isOpen = true;
                gameObject.SetActive(true);
                break;

            case StartingMenuStates.Disable:
                isOpen = false;
                gameObject.SetActive(false);
                break;
        }
    }

    protected virtual void OnDestroy()
    {
        if(MenuManager.IsValidSingleton())
            MenuManager.Instance.RemoveMenu(this);
    }
}
