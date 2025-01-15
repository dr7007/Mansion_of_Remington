using System.Collections;
using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine;

public class NetworkManager : MonoBehaviourPun
{
    [Header("플레이어 콜백 뿌리는 쪽")]
    [SerializeField]
    [Tooltip("처음 자물쇠 풀렸을때 콜백")]
    private LockInteraction openLock;
    [SerializeField]
    [Tooltip("기자가 누른 동물버튼 콜백")]
    private AnimalBoard wAnimalboard;
    [SerializeField]
    [Tooltip("거울 기믹 성공 콜백")]
    private MirrorP mirror;
    [SerializeField]
    [Tooltip("마네킹 퍼즐 성공 콜백")]
    private manneManager mane;
    [SerializeField]
    [Tooltip("유리 뿌서짐 콜백")]
    private glass glass1;


    [Header("플레이어 콜백 받는 쪽")]
    [SerializeField]
    [Tooltip("동물버튼 콜백을 받는 소년큐브2면")]
    private Cube2Sound bAnimalboard;
    [SerializeField]
    [Tooltip("소년")]
    private GameObject boy;
    [SerializeField]
    [Tooltip("기자")]
    private GameObject woman;
    [SerializeField]
    [Tooltip("포톤보이스")]
    private Recorder recorder;
    [SerializeField]
    [Tooltip("큐브 보내기")]
    private GResponse cubeResult;
    [SerializeField]
    [Tooltip("쇠사슬 보내기")]
    private GResponse ropeResult;
    [SerializeField]
    [Tooltip("책1 보내기")]
    private GResponse book1Result;
    [SerializeField]
    [Tooltip("책2 보내기")]
    private GResponse book2Result;
    [SerializeField]
    [Tooltip("퓨즈 보내기")]
    private GResponse puseResult;

    [Header("플레이어 생성 관련")]
    [SerializeField]
    [Tooltip("소년 프리팹")]
    private GameObject boyPrefab;
    [SerializeField]
    [Tooltip("기자 프리팹")]
    private GameObject womanPrefab;
    [SerializeField]
    [Tooltip("소년 생성 위치")]
    private Vector3 boyTr;
    [SerializeField]
    [Tooltip("기자 생성 위치")]
    private Vector3 womanTr;


    [Header("사진으로 보낼것들(소년쪽 오브젝트)")]
    [SerializeField]
    [Tooltip("큐브")]
    private GameObject cube;
    [SerializeField]
    [Tooltip("쇠사슬")]
    private GameObject chain;
    [SerializeField]
    [Tooltip("훅 활성화")]
    private HookAttach hook;
    [SerializeField]
    [Tooltip("책 2권중 첫번째책(book 착시퍼즐)")]
    private GameObject book1;
    [SerializeField]
    [Tooltip("책 2권중 두번째책(book 퍼즐)")]
    private GameObject book2;
    [SerializeField]
    [Tooltip("퓨즈")]
    private GameObject fuse;

    [Header("기자 쪽 생기는것들")]
    [SerializeField]
    [Tooltip("기자쪽 쇠사슬")]
    private GameObject wChain;
    [SerializeField]
    [Tooltip("기자쪽 망치")]
    private GameObject wHammer;
    [SerializeField]
    [Tooltip("기자쪽 마네킹후 책")]
    private GameObject womanTBook;


    [Header("책 4권 생성 관련")]
    [SerializeField]
    [Tooltip("소년방 책1")]
    private GameObject boyBook1;
    [SerializeField]
    [Tooltip("소년방 책2")]
    private GameObject boyBook2;
    [SerializeField]
    [Tooltip("소년방 책3")]
    private GameObject boyBook3;
    [SerializeField]
    [Tooltip("소년방 책4")]
    private GameObject boyBook4;
    [SerializeField]
    [Tooltip("소년방 책5")]
    private GameObject boyBook5;
    [SerializeField]
    [Tooltip("소년 힌트 1")]
    private GameObject boyHint1;
    [SerializeField]
    [Tooltip("기자 책1")]
    private GameObject womanBook1;
    [SerializeField]
    [Tooltip("기자 힌트 2")]
    private GameObject womanHint2;
    [SerializeField]
    [Tooltip("소년방 실루엣액자 collider")]
    private Collider[] planes = new Collider[4];


    [Header("키보드 동시에 누르기")]
    [SerializeField]
    [Tooltip("기자 키보드1 상태")]
    private KeyboardRPC wKeyBoard1;
    [SerializeField]
    [Tooltip("기자 키보드2 상태")]
    private KeyboardRPC wKeyBoard2;
    [SerializeField]
    [Tooltip("소년 키보드1 상태")]
    private KeyboardRPC bKeyBoard1;
    [SerializeField]
    [Tooltip("소년 키보드2 상태")]
    private KeyboardRPC bKeyBoard2;

    private bool keyboardSucess = false;
    private bool checkIsMine = false;
    private bool recorderOn = true;

    private void Start()
    {
        // 콜백 함수 등록
        if (openLock != null)
        {
            openLock.LockOpenCallback += BoyMove;
        }

        if (wAnimalboard != null)
        {
            wAnimalboard.animalBtnCallback += WCallbackAnimal;
        }

        if (glass1 != null)
        {
            glass1.glassSucessCallback += GlassSucess;
        }

        if (mirror != null)
        {
            mirror.mirroSucessCallback += MirrorSucess;
        }

        if (mane != null)
        {
            mane.manneSucessCallback += ManeSucess;
        }

        cubeResult.OnResponseCallback += CubeTransport;
        ropeResult.OnResponseCallback += RopeTransport;
        book1Result.OnResponseCallback += Book1Transport;
        book2Result.OnResponseCallback += Book2Transport;
        puseResult.OnResponseCallback += FuseTransport;


        // 플레이어 생성
        StartCoroutine(InstantiatePlayerCoroutine());
    }

    private void Update()
    {
        // 키보드 4개다 눌려졌을때 성공!
        if (wKeyBoard1 != null && wKeyBoard2 != null && bKeyBoard1 != null && bKeyBoard2 != null)
        {
            if (!keyboardSucess && wKeyBoard1.TheButtonisPressed && wKeyBoard2.TheButtonisPressed && bKeyBoard1.TheButtonisPressed && bKeyBoard2.TheButtonisPressed)
            {
                keyboardSucess = true;
                KeyboardSucess();
            }
        }

        // boy와 woman이 둘다 네트워크상에서 생성됬을때
        if (boy != null && woman != null && !checkIsMine)
        {
            if (boy.GetComponent<PhotonView>().IsMine)
            {
                woman.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (woman.GetComponent<PhotonView>().IsMine)
            {
                boy.transform.GetChild(0).gameObject.SetActive(false);
            }

            checkIsMine = true;
        }
    }

    #region 콜백 받는 쪽에서 실행되는 함수들
    private void BoyMove()
    {
        Debug.Log("boymove 해제 호출");

        // 소년이 움직일수 있도록 설정
        photonView.RPC("BoyMoveRPC", RpcTarget.Others);
    }

    private void WCallbackAnimal(string _animal)
    {
        // 소년에게 기자가 누른 버튼의 정보를 넘김.
        if (_animal == "Monkey")
        {
            bAnimalboard.CallbackMonkey();
        }

        if (_animal == "Mouse")
        {
            bAnimalboard.CallbackMouse();
        }
    }

    private void MirrorSucess()
    {
        photonView.RPC("MirrorSucessRPC", RpcTarget.Others);
    }

    private void ManeSucess()
    {
        photonView.RPC("ManeSucessRPC", RpcTarget.All);
    }

    private void GlassSucess()
    {
        photonView.RPC("GlassSucessRPC", RpcTarget.Others);
    }

    private void KeyboardSucess()
    {
        photonView.RPC("KeyboardSucessRPC", RpcTarget.All);
    }

    private void CubeTransport(bool _state)
    {
        photonView.RPC("CubeTransportRPC", RpcTarget.All);
    }

    private void RopeTransport(bool _state)
    {
        photonView.RPC("RopeTransportRPC", RpcTarget.Others);
    }

    private void Book1Transport(bool _state)
    {
        photonView.RPC("Book1TransportRPC", RpcTarget.Others);
    }

    private void Book2Transport(bool _state)
    {
        photonView.RPC("Book2TransportRPC", RpcTarget.Others);
    }

    private void FuseTransport(bool _state)
    {
        photonView.RPC("FuseTransportRPC", RpcTarget.Others);
    }
    #endregion

    #region PunRPC 함수
    [PunRPC]
    private void SetBoy(int _viewID)
    {
        boy = PhotonNetwork.GetPhotonView(_viewID).gameObject;
    }

    [PunRPC]
    private void SetWoman(int _viewID)
    {
        woman = PhotonNetwork.GetPhotonView(_viewID).gameObject;
    }

    [PunRPC]
    private void BoyMoveRPC()
    {
        Debug.LogError("Boy의 움직임 해제 rpc 호출됨.");

        Debug.LogError(boy.transform.GetChild(0).GetChild(0) + " : Locomotion이여야함");
        // boy가 움직일수 있게
        boy.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    [PunRPC]
    private void MirrorSucessRPC()
    {
        // 쇠사슬 생성
        if (wChain != null)
        {
            wChain.SetActive(true);
        }
    }

    [PunRPC]
    private void ManeSucessRPC()
    {
        // 아직 할당 안했으면 실행안됨.
        // if (boyBook1 == null || boyBook2 == null || boyBook3 == null || boyBook4 == null || boyBook5 == null || womanHint1 == null || womanHint2 == null) return;

        if (PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Boy")
        {
            // 소년일때 -> 책5권 활성화 + 힌트 1개 활성화
            boyBook1.SetActive(true);
            boyBook2.SetActive(true);
            boyBook3.SetActive(true);
            boyBook4.SetActive(true);
            boyBook5.SetActive(true);
            // boyHint1.SetActive(true);

            // 액자 collider 비활성화
            foreach(Collider col in planes)
            {
                col.enabled = false;
            }
        }
        else if (PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Woman")
        {
            // 기자일때 -> 힌트 2개를 기자 위치에
            womanTBook.SetActive(true);
            // womanHint2.SetActive(true);
        }
    }

    [PunRPC]
    private void GlassSucessRPC()
    {
        // 소년에게서 나레이션 재생


        // 서로 보이스 끊김
        if (recorderOn)
        {
            recorder.RecordingEnabled = false;
            recorderOn = false;
        }
        else
        {
            recorder.RecordingEnabled = true;
            recorderOn = true;
        }

    }

    [PunRPC]
    private void KeyboardSucessRPC()
    {
        if (PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Boy")
        {
            // 소년일때

        }
        else if (PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Woman")
        {
            // 기자일때
            wHammer.SetActive(true);
        }
    }

    [PunRPC]
    private void CubeTransportRPC()
    {
        if (cube != null) cube.SetActive(true);
    }

    [PunRPC]
    private void RopeTransportRPC()
    {
        if (chain != null) chain.SetActive(true);
        // 훅 활성화
        if (hook != null) hook.activeTrigger = true;
    }

    [PunRPC]
    private void Book1TransportRPC()
    {
        if (book1 != null) book2.SetActive(true);
    }

    [PunRPC]
    private void Book2TransportRPC()
    {
        if (book1 != null) book2.SetActive(true);
    }

    [PunRPC]
    private void FuseTransportRPC()
    {
        if (fuse != null) fuse.SetActive(true);
    }
    #endregion

    // 플레이어를 소환하는 함수
    private void InstantiatePlayer()
    {
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("Role") && PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Boy")
        {
            Debug.Log("소년 생성");

            // boy 생성
            boy = PhotonNetwork.Instantiate(boyPrefab.name, boyTr, Quaternion.Euler(0f, 180f, 0f));

            // ismine 키기
            boy.transform.GetChild(0).gameObject.SetActive(true);

            // boy 못움직이게 locomotion 비활성화
            boy.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

            // boy 설정
            photonView.RPC("SetBoy", RpcTarget.AllBuffered, boy.GetComponent<PhotonView>().ViewID);
        }
        else if(PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("Role") && PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Woman")
        {
            Debug.Log("기자 생성");

            // 기자 생성
            woman = PhotonNetwork.Instantiate(womanPrefab.name, womanTr, Quaternion.identity);

            // ismine 키기
            woman.transform.GetChild(0).gameObject.SetActive(true);

            // woman 설정
            photonView.RPC("SetWoman", RpcTarget.AllBuffered, woman.GetComponent<PhotonView>().ViewID);
        }
    }

    // 바로 생성하면 역할군 설정하는 시간때문에 오류가 나서 매프레임 들어왔는지 확인후에 생성
    private IEnumerator InstantiatePlayerCoroutine()
    {
        while (true)
        {
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("Role") == true)
            {
                InstantiatePlayer();
                break;
            }

            yield return null;
        }
    }
}
