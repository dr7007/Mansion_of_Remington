using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobyManager : MonoBehaviour
{
    private string[] dialogs;
    public Button[] buttonList;

    [SerializeField] private GameObject createPopup;
    [SerializeField] private GameObject findPopup;
    [SerializeField] private GameObject codePopup;
    [SerializeField] private GameObject errorPopup;

    [SerializeField] private Button joinBtn;
    [SerializeField] private Button codeBtn;

    [SerializeField] private TextMeshProUGUI errorText;

    [SerializeField] private TMP_InputField roomCode;

    [SerializeField] private Canvas selectCanvas;


    private void Start()
    {
        dialogs = new string[] {
            "Room Code Not Found!",
            "This Room is Full!",
        };
        joinBtn.onClick.AddListener(ClickJoin);
    }

    private void Update()
    {

    }

    // 방 만들기 눌렀을때
    public void OpenCreatePopUP()
    {
        createPopup.SetActive(true);
        codePopup.SetActive(false);
        findPopup.SetActive(false);
    }

    // 방 만들기 - 코드 입력 후 확인
    public void CreateRoom()
    {
        if(roomCode.text.Length < 5)
        {
            Debug.Log("NO");
        }
        else
        {
            // 방생성
        }
    }

    // 방 찾기 눌렀을때
    public void FindPopUP()
    {
        createPopup.SetActive(false);
        codePopup.SetActive(false);
        findPopup.SetActive(true);
    }



    ///////////////////////////방찾기 - 코드로 방찾기 부분///////////////////////////////
  

    
    // 코드로 방찾기
    public void CodePopUp()
    {
        codePopup.SetActive(true);
    }
    // 코드방팝업 닫기
    public void CodePopUpClose()
    {
        codePopup.SetActive(false);

    }

    // 확인 버튼 눌렀을 때
    public void CheckCode()
    {
        // 통과 - canvas 캐릭터 고르는 부분으로 넘김
        //selectCanvas.enabled = true;

        // 통과 안된경우

        // 1. 코드를 못찾은 경우
        // errorText.text = dialogs[0];
        // StartCoroutine(ErrorPopup());

        // 2. 인원이 다 찼을 때
        // errorText.text = dialogs[1];
        // StartCoroutine(ErrorPopup());

    }


    ////////////////////////방찾기 - 조인 버튼 부분//////////////////////////////////
    /*
        목록을 누르지 않고 조인버튼을 누른경우 - 에러팝업창
        목록을 누르고 조인 버튼을 누른 경우 - 1. 자리있음 - 캐릭터 선택 창으로 넘어감 / 2. 인원 초과 - 에러 팝업창
    */

    // 방 목록 눌렀을 때 호출될 함수
    // 인스펙터 창에서 직접 호출하는 경우
    public void ClickList()
    {

    }
    // 만약에 배열 사용하는 거면 반복문 돌리고 AddListener 사용
    // 배열[i].onClick.AddListener(() => { (함수); });
    
    //조인버튼 눌렀을 때 함수
    private void ClickJoin()
    {
        
    }

   

    ///////////////////////////////////////////////////////////////////////////////

    // 에러 팝업창 코루틴
    private IEnumerator ErrorPopup()
    {
        errorPopup.SetActive(true);
        yield return new WaitForSeconds(1f);
        errorPopup.SetActive(false);
        errorText.text = "";
    }


}
