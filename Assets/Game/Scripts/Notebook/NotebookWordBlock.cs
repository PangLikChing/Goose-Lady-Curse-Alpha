using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class NotebookWordBlock : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    CanvasGroup canvasGroup;

    public Transform DraggableClonePrefeb;

    [SerializeField] Image myImage;
    [SerializeField] TMP_Text myTextField;

    [HideInInspector] public NotebookDraggableWordBlock myClone;
    [HideInInspector] public NotebookReturnDroppingField returnDroppingField;
    [HideInInspector] public Canvas canvas;

    void Start()
    {
        // Initialize
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start dragging");

        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Instantiate a dragable word block
            myClone = InstantiateClone();

            // Snap myCLone's position to this transform's position to create the illusion of they are the same object
            myClone.transform.position = transform.position;

            // Hide this gameObject
            canvasGroup.alpha = 0;

            // Disable the drag-ability of this word block
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");

        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Move the dragged object with mouse
            myClone.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stopped dragging");

        // If I am dropping with a left mouse button
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If the clone is not dropped on top of a dropping field
            if (myClone.transform.parent.GetComponent<NotebookDroppingField>() == null)
            {
                // Destroy the clone's gameObject
                Destroy(myClone.gameObject);

                // Dereference myClone
                myClone = null;

                // Show the word block again
                canvasGroup.alpha = 1;

                // Enable dragging of this word block
                canvasGroup.blocksRaycasts = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    private NotebookDraggableWordBlock InstantiateClone()
    {
        // Instantiate a dragable word block
        myClone = Instantiate(DraggableClonePrefeb, canvas.transform).GetComponent<NotebookDraggableWordBlock>();

        // Ask the clone to remember this word block
        myClone.myOriginalGameObject = gameObject;

        // Assign canvas, sprite and word for the clone
        myClone.canvas = canvas;
        myClone.myImage.sprite = myImage.sprite;
        myClone.myTextField.text = myTextField.text;

        // Assign the return dropping field for the clone
        myClone.returnDroppingField = returnDroppingField;

        // Return the clone
        return myClone;
    }
}
