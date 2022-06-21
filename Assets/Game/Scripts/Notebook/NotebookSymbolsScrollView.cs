using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class NotebookSymbolsScrollView : MonoBehaviour
{
    [SerializeField] NotebookManager notebookManager;

    [SerializeField] Transform emojiTransformPrefeb;

    RectTransform content;

    void Awake()
    {
        // Initialize
        content = GetComponent<ScrollRect>().content;

        // If there is no child element for the content, aka the game just started
        if (content.childCount == 0)
        {
            // For every emoji stored in the emojis list in the notebook manager
            for (int i = 0; i < notebookManager.emojis.Length; i++)
            {
                // Instantiate an icon for the emoji block
                Image emojiImage = Instantiate(emojiTransformPrefeb, content).GetComponent<Image>();

                // Assign the coorrectsponding sprite for the emoji
                emojiImage.sprite = notebookManager.emojis[i];
            }
        }
    }
}
