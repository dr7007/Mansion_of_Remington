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

    // �����ϴ� ���̵�, ���� ����
    [SerializeField] private TextMeshProUGUI IDMessage;
    [SerializeField] private TextMeshProUGUI EmailMessage;

    // �Է¾��� ĭ �ִٰ� �˷��ִ� â
    [SerializeField] private GameObject EmptyBox;

    private void Awake()
    {
        // ��� �����ϰ� ���� �ڵ�
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
        // ��ĭ�� �ִٸ� �˾� ����
        if(Nick.text == "" || ID.text == "" || PW.text == "" || Email.text == "")
        {
           // Debug.Log("�����");
           StartCoroutine(Pop());

        }

        /*
        else if (���̵� �˻��ߴµ� �ִ� ������ ���)
        {
             IDMessage.enabled = true;
             
        }

        else if(���� �˻��ߴµ� �ִ� ������ ���)
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

    // ��ĭ�� �ִٰ� �˷��ִ� �˾� �ڷ�ƾ
    private IEnumerator Pop()
    {
        EmptyBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        EmptyBox.SetActive(false);
    }
}
