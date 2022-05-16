using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for scaling the display for the containers
/// 
/// It assumes that the grid layout group uses fixed column count
/// </summary>

public class InventoryScaler : MonoBehaviour
{
    RectTransform rect;
    GridLayoutGroup gridLayoutGroup;
    [SerializeField] Container myContainer;
    [SerializeField] GameObject inventorySlot;

    [SerializeField] PlayerInverntory playerInverntory;

    void OnEnable()
    {
        // Initialize
        rect = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        // Instanstate the number of slots needed for the inventory
        for (int i = 0; i < myContainer.heldItems.Length; i++)
        {
            Instantiate(inventorySlot, transform);
        }

        // Cache the number of columns
        int numberOfColumns = gridLayoutGroup.constraintCount;

        // Calculate the number of rows that the grid currently has
        int numberOfRows = transform.childCount / numberOfColumns;

        // If the remainder is not 0
        if (transform.childCount % gridLayoutGroup.constraintCount != 0)
        {
            // Increase the amount of rows by 1
            numberOfRows++;
        }

        // Calculate the new x size value
        float newSizeDeltaX = gridLayoutGroup.padding.left + (int)gridLayoutGroup.cellSize.x * numberOfColumns + numberOfColumns * gridLayoutGroup.spacing.x;

        // Calculate the new y size value
        float newSizeDeltaY = gridLayoutGroup.padding.top + (int)gridLayoutGroup.cellSize.y * numberOfRows + numberOfRows * gridLayoutGroup.spacing.y;

        // Change the rect transform's sizeDelta
        rect.sizeDelta = new Vector2(newSizeDeltaX, newSizeDeltaY);

        // Change the position of the grid
        rect.localPosition = new Vector3(-rect.sizeDelta.x, rect.position.y, 0);

        // Invoke the open event
        playerInverntory.Open.Invoke();
    }
}
