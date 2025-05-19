using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HidePlaceholderText : MonoBehaviour
{
     private TMP_InputField inputField;

    // Start is called before the first frame update
    void Awake()
    {
        if (inputField == null)
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(OnSelectInputField);
        inputField.onDeselect.AddListener(OnDeselectInputField);
    }

    void OnSelectInputField(string _)
    {
        if (inputField.placeholder != null)
        {
            inputField.placeholder.gameObject.SetActive(false);
        }
    }
    void OnDeselectInputField (string _)
    {
        if (inputField.text == "" && inputField != null)
        {
            inputField.placeholder.gameObject.SetActive(true);
        }
    }
}
