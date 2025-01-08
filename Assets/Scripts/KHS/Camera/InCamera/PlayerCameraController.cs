using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCameraController : MonoBehaviour
{
    #region

    public delegate void ScreenChangeDelegate();
    public delegate void CaptureDelegate();
    public delegate void TransferDelegate();

    private ScreenChangeDelegate screenChangeCallback;
    private CaptureDelegate captureCallback;
    private TransferDelegate transferCallback;

    public ScreenChangeDelegate ScreenChangeCallback
    {
        get { return screenChangeCallback; }
        set { screenChangeCallback = value; }
    }
    public CaptureDelegate CaptureCallback
    {
        get { return captureCallback; }
        set { captureCallback = value; }
    }
    public TransferDelegate TransferCallback
    {
        get { return transferCallback; }
        set { transferCallback = value; }
    }


    #endregion

    public GameObject leftPhysicalCamera; // 왼쪽 컨트롤러에 장착된 "물리 카메라"
    public GameObject leftController;
    public GameObject toyBlockTrigger;

    [Header("Input Actions")]
    public InputActionProperty aButtonPressAction;
    public InputActionProperty xButtonPressAction;
    public InputActionProperty rTriggerPressAction;
    public InputActionProperty lTriggerPressAction;

    [SerializeField]
    private Vector3 camOffset = Vector3.zero;

    private bool onCamera = false;

    private void Start()
    {
        // 초기 상태: "카메라" 비활성화
        leftPhysicalCamera.SetActive(false);
        leftPhysicalCamera.transform.localPosition = camOffset;
        onCamera = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other?.GetComponent<toyBlockPuzzle>())
        {
            Debug.Log("탐지범위 내");
            toyBlockTrigger = other.gameObject;
        }
    }

    private void OnEnable()
    {
        aButtonPressAction.action.performed += OnAButtonPressed;
        xButtonPressAction.action.performed += OnXButtonPressed;
        rTriggerPressAction.action.performed += OnRTriggerPressed;
        lTriggerPressAction.action.performed += OnLTriggerPressed;

        aButtonPressAction.action.Enable();
        xButtonPressAction.action.Enable();
        rTriggerPressAction.action.Enable();
        lTriggerPressAction.action.Enable();
    }
    private void OnDisable()
    {
        aButtonPressAction.action.performed -= OnAButtonPressed;
        xButtonPressAction.action.performed -= OnXButtonPressed;
        rTriggerPressAction.action.performed -= OnRTriggerPressed;
        lTriggerPressAction.action.performed -= OnLTriggerPressed;

        aButtonPressAction.action.Disable();
        xButtonPressAction.action.Disable();
        rTriggerPressAction.action.Disable();
        lTriggerPressAction.action.Dispose();
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        if (onCamera)
        {
            ScreenChangeCallback?.Invoke();
        }
        else
        {
            Debug.Log("Off Camera State");
        }
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("X Pressed");
        TogglePhysicalCamera();
    }

    private void OnRTriggerPressed(InputAction.CallbackContext context)
    {
        if (onCamera)
        {
            Debug.Log("OnRCapture");
            CaptureCallback?.Invoke();
            if(toyBlockTrigger != null)
            {
                Debug.Log("포인트 찾음");
                toyBlockTrigger.GetComponent<toyBlockPuzzle>().OnPhoto();
            }
        }
        else
        {
            Debug.Log("OnRTrigger");
        }
    }
    private void OnLTriggerPressed(InputAction.CallbackContext context)
    {
        if (onCamera)
        {
            Debug.Log("OnLTransfer");
            TransferCallback?.Invoke();
        }
        else
        {
            Debug.Log("OnLTrigger");
        }
    }
    void TogglePhysicalCamera()
    {
        onCamera = !onCamera;

        leftPhysicalCamera.SetActive(onCamera);
        leftController.SetActive(!onCamera);
    }
}
