using UnityEngine;

public class InventoryMove : MonoBehaviour
{
    public GameObject uiElement;
    public float distance = 5f;   
    private bool isUIVisible = false;  
    private Camera playerCamera;  
    private Vector3 uiFixedPosition;  

    void Start()
    {
        // 플레이어 카메라 초기화
        playerCamera = Camera.main;

        // 처음에는 UI가 비활성화
        uiElement.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleUI();
        }
    }

    // UI를 보이거나 숨기는 함수
    void ToggleUI()
    {
        isUIVisible = !isUIVisible;

        if (isUIVisible)
        {
            // 오른쪽 30도
            Vector3 rightDirection = (playerCamera.transform.right + playerCamera.transform.forward + playerCamera.transform.forward).normalized;

            // 원하는 거리만큼 떨어져서
            uiFixedPosition = playerCamera.transform.position + rightDirection * distance;

            // 해당 위치로 이동
            uiElement.transform.position = uiFixedPosition;

            // ui를 카메라 바라보게 회전
            uiElement.transform.rotation = Quaternion.LookRotation(uiElement.transform.position - playerCamera.transform.position);

            // ui를 킴.
            uiElement.SetActive(true);
        }
        else
        {
            uiElement.SetActive(false);
        }
    }
}

