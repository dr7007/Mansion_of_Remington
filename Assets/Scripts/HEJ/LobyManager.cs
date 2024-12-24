using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class LobyManager : MonoBehaviourPunCallbacks
{
    private string[] dialogs;
    public Button[] buttonList;

    [SerializeField] private GameObject createPopup;
    [SerializeField] private GameObject findPopup;
    [SerializeField] private GameObject codePopup;
    [SerializeField] private GameObject errorPopup;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private GameObject contentRoom;

    [SerializeField] private Button joinBtn;
    [SerializeField] private Button codeBtn;

    [SerializeField] private TextMeshProUGUI errorText;

    [SerializeField] private TMP_InputField roomCode;

    [SerializeField] private Canvas selectCanvas;

    private bool firstEnter = false;



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
            CreatePhotonRoom(roomCode.text);
        }
    }

    // 방 찾기 눌렀을때
    public void FindPopUP()
    {
        createPopup.SetActive(false);
        codePopup.SetActive(false);
        findPopup.SetActive(true);

        // 로비로 들어가기
        PhotonNetwork.JoinLobby();
    }

    // 로그아웃 눌렀을때
    public void LoginOut()
    {
        // 포톤 서버와 연결끊기
        PhotonNetwork.Disconnect();

        // 다시 로비씬으로
        // 스크립트 이름이 SceneManager면 화나요
        UnityEngine.SceneManagement.SceneManager.LoadScene("HEJ_Scene");
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


    private void CreatePhotonRoom(string _roomname)
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(_roomname, roomOptions, TypedLobby.Default);
    }

    // 룸 갱신 함수
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Transform[] children2 = contentRoom.transform.GetComponentsInChildren<Transform>();

        List<Transform> childrenList = new List<Transform>();

        // 자식중에 프리펩만 가져오도록 수정
        foreach (Transform child in children2)
        {
            if (child.tag == "P_List")
            {
                childrenList.Add(child);
            }
        }

        Transform[] children = childrenList.ToArray();

        // 처음 들어갔을때 방정보들 setting
        if (firstEnter)
        {
            foreach (Transform child in children)
            {
                Destroy(child.gameObject);
            }
            firstEnter = false;
        }

        // 방생성
        foreach (RoomInfo room in roomList)
        {
            // 각 방에 대해 프리팹 인스턴스화
            GameObject roomItem = Instantiate(roomPrefab, contentRoom.transform);

            // 0번째 자식에 룸 이름 넣기
            TMP_Text roomNameText = roomItem.transform.GetChild(0).GetComponent<TMP_Text>();
            if (roomNameText != null)
            {
                roomNameText.text = "Room: " + room.Name;
            }

            // 1번째 자식에 플레이어 수 넣기
            TMP_Text playerNameText = roomItem.transform.GetChild(1).GetComponent<TMP_Text>();
            if (playerNameText != null)
            {
                playerNameText.text = "Players: " + room.PlayerCount + "/" + room.MaxPlayers;
            }
        }

        children2 = contentRoom.transform.GetComponentsInChildren<Transform>();

        childrenList = new List<Transform>();

        // 자식중에 프리펩만 가져오도록 수정
        foreach (Transform child in children2)
        {
            if (child.tag == "P_List")
            {
                childrenList.Add(child);
            }
        }

        children = childrenList.ToArray();

        if (!firstEnter) // 실시간 방 상태 전달함.
        {
            // 플레이어 카운트0 (방나간 상태)
            if (roomList[0].PlayerCount == 0)
            {
                foreach (Transform child in children)
                {
                    if ("Room: " + roomList[0].Name == child.GetChild(0).GetComponent<TMP_Text>().text)
                    {
                        Destroy(child.gameObject);
                    }

                }
            }
        }
    }

    // 방 생성 성공 시 호출되는 콜백
    public override void OnCreatedRoom()
    {
        Debug.Log("방이 성공적으로 생성되었습니다.");
    }

    // 룸 들어가면 호출
    public override void OnJoinedRoom()
    {
        Debug.Log("방에 성공적으로 들어감");
    }

    // 방 생성 실패 시 호출되는 콜백
    public override void OnCreateRoomFailed(short errorCode, string errorMessage)
    {
        Debug.LogError("방 생성 실패! 에러 코드: " + errorCode + ", 메시지: " + errorMessage);
    }

    // 로비 입장 성공시 호출
    public override void OnJoinedLobby()
    {
        firstEnter = true;
        Debug.Log("로비입장 성공!");
    }

    // 로비 나가면 호출
    public override void OnLeftLobby()
    {
        firstEnter = false;
        Debug.Log("로비 나감!");
    }
}
