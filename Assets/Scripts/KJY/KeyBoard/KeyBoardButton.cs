using TMPro;
using UnityEngine;

public class KeyBoardButton : MonoBehaviour
{
    private KeyBoard keyBaord;
    private TextMeshProUGUI buttonText;

    private void Start()
    {
        keyBaord = GetComponentInParent<KeyBoard>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if(buttonText.text.Length ==1)
        {
            NameToButtonText();
            GetComponentInChildren<ButtonVR>().onRelease.AddListener(delegate { keyBaord.InsertChar(buttonText.text); });
        }
    }

    private void NameToButtonText()
    {
        buttonText.text = gameObject.name;
    }

}