using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoginManager : MonoBehaviour
{
    private Button Signin;
    private string[] dialogs;

    [SerializeField] private TMP_InputField Id;
    [SerializeField] private TMP_InputField Pw;
    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI textBox;

    private void Awake()
    {
        
        Signin = GetComponent<Button>();
    }
    private void Update()
    {
        //dsada
    }

    private void Start()
    {
        textBox.text = "";
        dialogs = new string[] {
            "Check your ID",
            "Check your PW",
        };
        
    }

    public void Check()
    {
        if(Id.text == "")
        {
            popup.SetActive(true);
            textBox.text = dialogs[0];
        }
        else if (Pw.text == "")
        {
            popup.SetActive(true);
            textBox.text = dialogs[1];
        }
       // DB ºñ±³
       // else if ()
    }

    public void onClickXBtn() {

        popup.SetActive(false);
    }
}
