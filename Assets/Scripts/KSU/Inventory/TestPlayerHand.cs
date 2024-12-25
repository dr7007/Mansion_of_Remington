using UnityEngine;

public class TestPlayerHand : MonoBehaviour
{
    public Camera playerCamera;           // 플레이어의 카메라
    public float raycastDistance = 5f;    // 레이캐스트 거리
    public LayerMask interactableLayer;   // 상호작용할 수 있는 오브젝트의 레이어
    public Transform handTransform;       // 손의 위치

    private GameObject grabbedObject;     // 잡은 오브젝트
    private bool isGrabbing = false;      // 그랩 상태 체크

    void Update()
    {
        // 우클릭 (마우스 버튼 1)으로 상호작용 시작
        if (Input.GetMouseButtonDown(1) && !isGrabbing)
        {
            TryGrabObject();
        }

        // 우클릭을 놓으면 그랩 해제
        if (Input.GetMouseButtonUp(1) && isGrabbing)
        {
            ReleaseObject();
        }

        // 그랩 중일 때 오브젝트 위치를 손 위치에 따라 이동
        if (isGrabbing && grabbedObject != null)
        {
            FollowHandPosition();
        }
    }

    // Raycast로 오브젝트를 감지하고 잡기
    void TryGrabObject()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {
            // Raycast가 Interaction 레이어에 있는 오브젝트를 감지했을 때
            grabbedObject = hit.collider.gameObject;

            // 오브젝트가 감지되면 그랩 상태로 설정
            isGrabbing = true;

            // 오브젝트가 물리적으로 따라다닐 수 있도록 Rigidbody의 Kinematic을 설정
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    // 손 위치로 오브젝트를 따라다니게 함
    void FollowHandPosition()
    {
        // 오브젝트를 손 위치로 이동
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = handTransform.position;
        }
    }

    // 오브젝트를 놓기
    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            // 오브젝트가 놓였을 때 물리적 상호작용을 복원
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            grabbedObject = null;
            isGrabbing = false;
        }
    }
}

