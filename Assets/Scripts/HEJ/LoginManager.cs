using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections;

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

        // DB 비교
        StartCoroutine(LoginCoroutine(Id.text, Pw.text));

       // else if ()
    }

    public void onClickXBtn() {

        popup.SetActive(false);
    }

    private IEnumerator LoginCoroutine(string _id, string _pw)
    {
        string loginUri = "http://34.47.102.147/gameLogin.php";

        WWWForm form = new WWWForm();
        form.AddField("LoginID", _id);
        form.AddField("LoginPW", _pw);

        using (UnityWebRequest www = UnityWebRequest.Post(loginUri, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log(www.error);
            }
            else if (www.downloadHandler.text == "IDError" || www.downloadHandler.text == "PWError")
            {
                // IDError or PWError일때 실행됨.
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                // 아무 오류안나면 실행됨.
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
