using UnityEngine;
using UnityEngine.UI;
public class ComputerBoard : MonoBehaviour
{
    [SerializeField] private GameObject passwordScreen;
    [SerializeField] private Image LoginImg;
    [SerializeField] private Image CCTVIMg;
    [SerializeField] private Image MailIMg;
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject mailScreen;
    [SerializeField] private GameObject cctvScreen;


    [SerializeField] private Button CCTVButton;
    [SerializeField] private Button MailButton;
    [SerializeField] private Button MemoButton;

    private bool Result = false;


    private void Start()
    {
        CCTVButton.onClick.AddListener(CCTVButtonOnClick);
    }

    private void LoginEvent()
    {
        if(Result == true)
        {
            LoginImg.enabled = false;
            passwordScreen.SetActive(false);
            mainScreen.SetActive(true);
            Result = false;
        }
    }

    private void CCTVButtonOnClick()
    {
        mainScreen.SetActive(false);
        passwordScreen.SetActive(true);
        CCTVIMg.enabled = true;
    }

    private void CCTVEvent()
    {
        if(Result == true)
        {
            CCTVIMg.enabled = false;
            passwordScreen.SetActive(false);
            cctvScreen.SetActive(true);
            Result = false;
        }
    }

}
