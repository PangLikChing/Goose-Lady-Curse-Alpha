using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class CraftingNumberInputField : MonoBehaviour
{
    TMP_InputField inputField;

    void Start()
    {
        // Initialize
        inputField = GetComponent<TMP_InputField>();
    }

    public void IncraseStackNumberByOne()
    {
        // If the stack number currently is smaller than 99
        if (int.Parse(inputField.text) < 99)
        {
            // Incrase stack number by 1
            inputField.text = (int.Parse(inputField.text) + 1).ToString();

            // Update craftable
            CraftingManager.Instance.CheckReagents();
        }
    }

    public void DecraseStackNumberByOne()
    {
        // If the stack number currently is larger than 1
        if (int.Parse(inputField.text) > 1)
        {
            // Derease stack number by 1
            inputField.text = (int.Parse(inputField.text) - 1).ToString();

            // Update craftable
            CraftingManager.Instance.CheckReagents();
        }
    }

    public void ResetStackNumber()
    {
        // Reset stack number to 1
        inputField.text = "1";

        // Update craftable
        CraftingManager.Instance.CheckReagents();
    }
}
