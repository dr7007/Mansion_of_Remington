using UnityEngine;
using Photon.Pun;

public class BBrick : MonoBehaviourPun
{
    public float maxDistance;
    public WBrick linkWBrick;
    private Vector3 startPos = Vector3.zero;
    private Quaternion initialRotation;

    private void Start()
    {
        startPos = transform.position;
        initialRotation = transform.rotation;
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
        }
    }

    // 제한 거리 설정하는 함수
    private void SetMaxDis()
    {
        float distanceFromStart = Vector3.Distance(startPos, transform.position);

        // 제한 거리에 도달했을때
        if (distanceFromStart > maxDistance)
        {
            Vector3 direction = transform.position - startPos;
            direction = direction.normalized * maxDistance;
            transform.position = startPos + direction;

            // 그랩을 놓도록 설정하면 될듯!
        }
    }
}
