using Photon.Pun;
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
    [Tooltip("카메라 보내기 기능 콜백")]
    private GameObject cam;
    [SerializeField]
    [Tooltip("거울 기믹 성공 콜백")]
    private GameObject mirror;
    [SerializeField]
    [Tooltip("마네킹 퍼즐 성공 콜백")]
    private manneManager mane;
    [SerializeField]
    [Tooltip("기자 키보드 누름 콜백")]
    private GameObject wKeyBoard;
    [SerializeField]
    [Tooltip("소년 키보드 누름 콜백")]
    private GameObject bKeyBoard;
    [SerializeField]
    [Tooltip("유리 뿌서짐 콜백")]
    private parents glass;


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

    [Header("사진으로 보낼것들")]
    [SerializeField]
    [Tooltip("기자 튜토리얼 방의 큐브")]
    private GameObject cube;
    [SerializeField]
    [Tooltip("쇠사슬")]
    private GameObject chain;
    [SerializeField]
    [Tooltip("책 2권중 첫번째책(book 착시퍼즐)")]
    private GameObject book1;
    [SerializeField]
    [Tooltip("책 2권중 두번째책(book 퍼즐)")]
    private GameObject book2;
    [SerializeField]
    [Tooltip("퓨즈")]
    private GameObject fuse;

    [Header("책 4권 생성 관련")]
    [SerializeField]
    [Tooltip("소년방 책1")]
    private GameObject boyBook1;
    [SerializeField]
    [Tooltip("소년방 책2")]
    private GameObject boyBook2;
    [SerializeField]
    [Tooltip("소년방 책1 위치")]
    private Vector3 boyBook1Tr;
    [SerializeField]
    [Tooltip("소년방 책2 위치")]
    private Vector3 boyBook2Tr;
    [SerializeField]
    [Tooltip("소년 힌트 1")]
    private GameObject boyHint1;
    [SerializeField]
    [Tooltip("소년 힌트 2")]
    private GameObject boyHint2;
    [SerializeField]
    [Tooltip("기자 힌트 1")]
    private GameObject womanHint1;
    [SerializeField]
    [Tooltip("기자 힌트 2")]
    private GameObject womanHint2;

    private void Start()
    {
        // 콜백 함수 등록
        openLock.LockOpenCallback += BoyMove;
        wAnimalboard.animalBtnCallback += WCallbackAnimal;

        // 플레이어 생성
        InstantiatePlayer();
    }

    #region 콜백 받는 쪽에서 실행되는 함수들
    private void BoyMove()
    {
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

    private void SendObject(string _name)
    {
        // 이름에 따라 소년위치에 생성(소년 한테서만 호출됨)
        photonView.RPC("SendObjectRPC", RpcTarget.Others, _name);
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
        // boy가 움직일수 있게
    }

    [PunRPC]
    private void SendObjectRPC(string _name)
    {
        // 이름에 따라 소년위치에 다른 프리펩들 생성
        switch(_name)
        {
            case "cube":
                Instantiate(cube, boy.transform.position, Quaternion.identity);
                break;
            case "chain":
                Instantiate(chain, boy.transform.position, Quaternion.identity);
                break;
            case "book1":
                Instantiate(book1, boy.transform.position, Quaternion.identity);
                break;
            case "book2":
                Instantiate(book2, boy.transform.position, Quaternion.identity);
                break;
            case "fuse":
                Instantiate(fuse, boy.transform.position, Quaternion.identity);
                break;
        }
    }

    [PunRPC]
    private void MirrorSucessRPC()
    {
        // 쇠사슬 생성
        Instantiate(chain, woman.transform.position, Quaternion.identity);
    }

    [PunRPC]
    private void ManeSucessRPC()
    {
        if (PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Boy")
        {
            // 소년일때 -> 책2권 생성, 힌트 2개를 소년 위치에
            Instantiate(boyBook1, boyBook1Tr, Quaternion.identity);
            Instantiate(boyBook2, boyBook2Tr, Quaternion.identity);
            Instantiate(boyHint1, boy.transform.position, Quaternion.identity);
            Instantiate(boyHint2, boy.transform.position, Quaternion.identity);
        }
        else
        {
            // 기자일때 -> 힌트 2개를 기자 위치에
            Instantiate(womanHint1, woman.transform.position, Quaternion.identity);
            Instantiate(womanHint2, woman.transform.position, Quaternion.identity);
        }
    }

    [PunRPC]
    private void GlassSucessRPC()
    {
        // 소년에게서 나레이션 재생
    }
    #endregion

    // 플레이어를 소환하는 함수
    private void InstantiatePlayer()
    {
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("Role") && PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Boy")
        {
            // boy 생성
            boy = PhotonNetwork.Instantiate(boyPrefab.name, boyTr, Quaternion.identity);

            // boy 못움직이게


            // boy 설정
            photonView.RPC("SetBoy", RpcTarget.AllBuffered, boy.GetComponent<PhotonView>().ViewID);
        }
        else
        {
            // 기자 생성
            woman = PhotonNetwork.Instantiate(womanPrefab.name, womanTr, Quaternion.identity);

            // woman 설정
            photonView.RPC("SetWoman", RpcTarget.AllBuffered, woman.GetComponent<PhotonView>().ViewID);
        }
    }
}
