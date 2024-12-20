using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Collections;


public class SignUpManager : MonoBehaviour
{
    private Button SignUp;

    [SerializeField] private GameObject SignUpBox;
    [SerializeField] private TMP_InputField Nick;
    [SerializeField] private TMP_InputField ID;
    [SerializeField] private TMP_InputField PW;
    [SerializeField] private TMP_InputField Email;

    // 존재하는 아이디, 메일 문구
    [SerializeField] private TextMeshProUGUI IDMessage;
    [SerializeField] private TextMeshProUGUI EmailMessage;

    // 입력안한 칸 있다고 알려주는 창
    [SerializeField] private GameObject EmptyBox;

    private void Awake()
    {
        // 영어만 가능하게 막는 코드
        ID.onValueChanged.AddListener((word) => ID.text = Regex.Replace(word, @"[^a-zA-Z]", ""));
    }
    private void Start()
    {
        SignUp = GetComponent<Button>();
        IDMessage.enabled = false;
        EmailMessage.enabled = false;
    }

    public void check()
    {
        // 빈칸이 있다면 팝업 실행
        if(Nick.text == "" || ID.text == "" || PW.text == "" || Email.text == "")
        {
           // Debug.Log("비었음");
           StartCoroutine(Pop());

        }

        /*
        else if (아이디 검사했는데 있는 메일인 경우)
        {
             IDMessage.enabled = true;
             
        }

        else if(메일 검사했는데 있는 메일인 경우)
        {
            EmailMessage.enabled = true;
        }
        */


    }
    public void OpenPopUp()
    {
        SignUpBox.SetActive(true);
    }
    public void ClosePopUp()
    {
        SignUpBox.SetActive(false);
    }

    // 빈칸이 있다고 알려주는 팝업 코루틴
    private IEnumerator Pop()
    {
        EmptyBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        EmptyBox.SetActive(false);
    }
}
