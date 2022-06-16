using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIScaler : MonoBehaviour
{
    // gridLayoutGroup is the GridLayoutGroup that the grouper is holding
    GridLayoutGroup gridLayoutGroup;

    // rectTransform is the RectTransform that the grouper is holding
    RectTransform rectTransform;

    void Awake()
    {
        // Initialize
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
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
        float newSizeDeltaX = gridLayoutGroup.padding.left + (int)gridLayoutGroup.cellSize.x * numberOfColumns + gridLayoutGroup.spacing.x * numberOfColumns;

        // Calculate the new y size value
        float newSizeDeltaY = gridLayoutGroup.padding.top + (int)gridLayoutGroup.cellSize.y * numberOfRows + gridLayoutGroup.spacing.y * numberOfColumns;

        // Change the rect transform's sizeDelta
        rectTransform.sizeDelta = new Vector2(newSizeDeltaX, newSizeDeltaY);
    }
}
