using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCameraController : MonoBehaviour
{
    public GameObject leftPhysicalCamera; // 왼쪽 컨트롤러에 장착된 "물리 카메라"
    public GameObject leftController;

    [SerializeField]
    private InputActionReference xrControllerAction = null;
    [SerializeField]
    private Vector3 camOffset = Vector3.zero;


    private bool isLeftCameraActive = false;

    private void Start()
    {
        // 초기 상태: "카메라" 비활성화
        leftPhysicalCamera.SetActive(false);
        leftPhysicalCamera.transform.localPosition = camOffset;
    }

    private void OnEnable()
    {
        xrControllerAction.action.started += OnXButtonPressed;
        xrControllerAction.action.canceled += OnXButtonReleased;
        xrControllerAction.action.Enable();
    }
    private void OnDisable()
    {
        xrControllerAction.action.started -= OnXButtonPressed;
        xrControllerAction.action.canceled -= OnXButtonReleased;
        xrControllerAction.action.Disable();
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("X Pressed");
        TogglePhysicalCamera();
    }
    private void OnXButtonReleased(InputAction.CallbackContext context)
    {
        Debug.Log("X Released");
    }

    void TogglePhysicalCamera()
    {
        isLeftCameraActive = !isLeftCameraActive;

        leftPhysicalCamera.SetActive(isLeftCameraActive);
        leftController.SetActive(!isLeftCameraActive);
    }
}
