using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class NotebookSymbolsScrollView : MonoBehaviour
{
    [SerializeField] NotebookManager notebookManager;

    [SerializeField] Transform emojiTransformPrefeb;

    [SerializeField] Scrollbar myScrollbar, dropFieldScrollbar;

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

        // Try to cache the vertical layout group of the content
        try
        {
            VerticalLayoutGroup contentVerticalLayoutGroup = content.GetComponent<VerticalLayoutGroup>();

            // Calculate the height of the content depends on the amount of child it has
            content.sizeDelta = new Vector2(0,
                (emojiTransformPrefeb.GetComponent<RectTransform>().rect.height
                + contentVerticalLayoutGroup.spacing) * content.transform.childCount
                + contentVerticalLayoutGroup.padding.top
                + contentVerticalLayoutGroup.padding.bottom);
        }
        catch
        {
            // Throw a debug message
            Debug.Log("There is no vertical layout group in the content");
        }
    }

    public void ChangeValue()
    {
        // Sync the value of the 2 scrollbars
        myScrollbar.value = dropFieldScrollbar.value;
    }
}
