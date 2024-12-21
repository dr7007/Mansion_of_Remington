using UnityEngine;
using UnityEngine.UI;

public class LobyManager : MonoBehaviour
{
    private string[] dialogs;

    [SerializeField] private GameObject CreatePopup;
    [SerializeField] private GameObject FindPopup;
    [SerializeField] private GameObject CodePopup;
    [SerializeField] private GameObject ErrorPopup;
    [SerializeField] private RawImage RawContent;

    private void Start()
    {
        dialogs = new string[] {
            "Room ID Not Found!",
            "This Room is Full!",
        };


    }
    public void OpenCreatePopUP()
    {
        CreatePopup.SetActive(true);
        FindPopup.SetActive(false);

    }

    public void FindPopUP()
    {
        CreatePopup.SetActive(false);
        FindPopup.SetActive(true);
    }

    public void pickContent()
    {
       // RawContent.material.color = new Color(97, 118, 102);
        Debug.Log("change");
    }
}
