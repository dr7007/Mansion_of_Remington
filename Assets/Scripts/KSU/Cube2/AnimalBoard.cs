using System.Collections;
using UnityEngine;
using Photon.Pun;

public class AnimalBoard : MonoBehaviourPun
{
    public delegate void AnimalBoardDelegate(string _animal);
    public AnimalBoardDelegate animalBtnCallback;

    [SerializeField]
    private GameObject rotateGo; // 돌릴 장치
    [SerializeField]
    private float rotateTime; // 돌리는데 걸리는 시간
    [SerializeField]
    private GameObject monkeyBtn;
    [SerializeField]
    private GameObject pigBtn;

    private GResponse res;

    private void Awake()
    {
        res = GetComponent<GResponse>();
    }

    private void Start()
    {
        res.OnResponseCallback += Interaction;
    }
    

    // 동물 석상 장치를 풀었을때 발생하는 함수
    private void Interaction(bool _state)
    {
        // 장치가 돌아가도록
        StartCoroutine(RotateGoCoroutine());
    }

    // 1초동안 180도 돌림
    private IEnumerator RotateGoCoroutine()
    {
        float elapseTime = 0f;

        while (elapseTime < rotateTime)
        {
            elapseTime += Time.deltaTime;

            rotateGo.transform.Rotate(0f, 0f, (180f * Time.deltaTime) / rotateTime);

            yield return null;
        }
    }

    // 몽키 버튼 눌렀을때
    private void PressMonkeyBtn()
    {
        photonView.RPC("PressMonkeyBtnRPC", RpcTarget.Others);
    }

    // 쥐 버튼 눌렀을때
    private void PressMouseBtn()
    {
        photonView.RPC("PressMouseBtnRPC", RpcTarget.Others);
    }

    [PunRPC]
    private void PressMonkeyBtnRPC()
    {
        animalBtnCallback?.Invoke("Monkey");
    }

    [PunRPC]
    private void PressMouseBtnRPC()
    {
        animalBtnCallback?.Invoke("Mouse");
    }
}
