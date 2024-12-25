using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;       // 이동 속도
    public float lookSpeedX = 2f;      // 마우스 X 회전 속도
    public float lookSpeedY = 2f;      // 마우스 Y 회전 속도
    public float jumpForce = 5f;       // 점프 힘
    public float gravity = -9.81f;     // 중력

    private float rotationX = 0f;      // Y축 회전 각도
    private Camera playerCamera;       // 플레이어의 카메라
    private CharacterController controller; // CharacterController 컴포넌트

    private Vector3 velocity;          // 중력과 점프를 적용한 속도

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();  // 카메라 초기화
        controller = GetComponent<CharacterController>();  // CharacterController 초기화
        Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서 숨기기
        Cursor.visible = false;  // 마우스 커서 숨기기
    }

    void Update()
    {
        // 이동 처리
        MovePlayer();

        // 마우스 회전 처리
        LookAround();
    }

    // 이동 함수
    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");  // A/D (좌우)
        float moveZ = Input.GetAxis("Vertical");    // W/S (앞뒤)

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // 중력 적용
        if (controller.isGrounded)
        {
            velocity.y = -2f;  // 바닥에 있을 때는 가벼운 중력 적용 (떨어지지 않게)
            if (Input.GetButtonDown("Jump"))  // 점프 처리
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);  // 점프 계산
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;  // 중력 적용 (공중에 있을 때)
        }

        // 이동 처리
        controller.Move((moveDirection * moveSpeed + velocity) * Time.deltaTime);
    }

    // 마우스 회전 처리
    void LookAround()
    {
        // 마우스 좌우 회전
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        transform.Rotate(Vector3.up * mouseX);  // Y축 회전 (좌우)

        // 마우스 상하 회전
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // 상하 회전 각도 제한
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);  // 카메라 회전
    }
}
