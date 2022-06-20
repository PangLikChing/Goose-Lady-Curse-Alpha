using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotebookDraggableWordBlock : MonoBehaviour
{
    public Image myImage;
    public TMP_Text myTextField;
    [HideInInspector] public RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
