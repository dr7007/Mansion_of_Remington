using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BBrick : MonoBehaviourPun
{
    public float maxDistance;
    public WBrick linkWBrick;
    public WBrick linkWBrick2;
    private Vector3 startPos = Vector3.zero;
    private Quaternion initialRotation;
    private bool isGrab;        
    private Transform handTr;
    private XRGrabInteractable grab;

    private void Start()
    {
        startPos = transform.position;
        initialRotation = transform.rotation;
        grab = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        // 소년일때만 실행
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("Role") && PhotonNetwork.LocalPlayer.CustomProperties["Role"].ToString() == "Boy")
        {
            Vector3 changePos = startPos - transform.position;

            // 각도 고정
            transform.rotation = initialRotation;

            // 거리 제한
            SetMaxDis();

            // 연결된 벽돌 이동
            linkWBrick.MoveWBrick(changePos);
            linkWBrick2.MoveWBrick(changePos);
        }

        if (isGrab)
        {
            transform.position = new Vector3(handTr.position.x, transform.position.y, transform.position.z);
        }
    }

    // 제한 거리 설정하는 함수
    private void SetMaxDis()
    {
        float distanceFromStart = Vector3.Distance(startPos, transform.position);

        // 제한 거리에 도달했을때
        if (distanceFromStart > maxDistance)
        {
            grab.enabled = false;

            Vector3 direction = transform.position - startPos;
            direction = direction.normalized * maxDistance;
            transform.position = startPos + direction;

            // 그랩을 놓도록 설정하면 될듯!
            grab.enabled = true;
        }
    }

    // 들어온 핸드의 위치값을 가져와서
    // 그 값의 특정 좌표를 추적(exit 될때까지)
    
    // 그랩이 됬을때
    public void OnGrab(SelectEnterEventArgs args)
    {
        isGrab = true;

        // 손의 정보를 가져옴.
        handTr = args.interactorObject.transform;

    }

    // 그랩을 놨을때
    public void OffGrab(SelectExitEventArgs args)
    {
        isGrab = false;

        // 손의 정보를 null로
        handTr = null;
    }
}
