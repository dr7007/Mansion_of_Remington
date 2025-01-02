using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{
    public TMP_InputField InputTheText;
    public GameObject NormalButton;
    public GameObject CapsButton;
    private bool caps;


    //Á¤´äµé
    private string TheLoginResult = "1234";
    private string TheCCTVResult = "1234";
    private string TheCCTVYearResult = "19780416";
    private string TheMailResult = "1234";
    private string TheMail2Result = "2495";

    private int curStep = 0;

    private void Start()
    {
        caps = false;
    }

    public void InsertChar(string C)
    {
        InputTheText.text += C;
    }
    public void DeleteChar()
    {
        if(InputTheText.text.Length > 0)
        {
            InputTheText.text = InputTheText.text.Substring(0, InputTheText.text.Length - 1);
        }
    }
    public void InputSpace()
    {
        InputTheText.text += " ";
    }
    public void CapsPressed()
    {
        if(!caps)
        {
            NormalButton.SetActive(false);
            CapsButton.SetActive(true);
            caps = true;
        }
        else
        {
            CapsButton.SetActive(false);
            NormalButton.SetActive(true);
            caps = false;
        }
    }

    public void EnterKey()
    {

        if (curStep == 0)
        {

        }
        else if (curStep == 2)
        {

        }
        else if(curStep == 3)
        {

        }
    }
    


}
