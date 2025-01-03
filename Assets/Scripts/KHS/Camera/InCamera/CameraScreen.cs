using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScreen : MonoBehaviour
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

    [SerializeField]
    private MeshRenderer screenMR = null;
    [SerializeField]
    private RenderTexture presentScreen = null;
    [SerializeField]
    private RenderTexture pastScreen = null;
    [SerializeField]
    private InputActionReference xrControllerAction = null;

    private bool isPast = false;


    public bool IsPast
    {
        get { return isPast; }
    }

    private void Start()
    {
        isPast = false;
        screenMR.material.SetTexture("_BaseMap", presentScreen);
        screenMR.material.SetTexture("_EmissionMap", presentScreen);
    }

    private void OnEnable()
    {
        xrControllerAction.action.started += OnAButtonPressed;
        xrControllerAction.action.canceled += OnAButtonReleased;
        xrControllerAction.action.Enable();
    }
    private void OnDisable()
    {
        xrControllerAction.action.started -= OnAButtonPressed;
        xrControllerAction.action.canceled -= OnAButtonReleased;
        xrControllerAction.action.Disable();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q Pressed");
            if (screenMR.isVisible)
            {
                isPast = !isPast;
                ScreenChangeCallback?.Invoke();
                ChangeRenderTex();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            TransferCallback?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F Pressed");
            CaptureCallback?.Invoke();
        }
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("A Pressed");
        if (screenMR.isVisible)
        {
            isPast = !isPast;
            ScreenChangeCallback?.Invoke();
            ChangeRenderTex();
        }
    }
    private void OnAButtonReleased(InputAction.CallbackContext context)
    {
        Debug.Log("A Released");
    }

    private void ChangeRenderTex()
    {
        if(!isPast)
        {
            screenMR.material.SetTexture("_BaseMap", presentScreen);
            screenMR.material.SetTexture("_EmissionMap", presentScreen);
        }
        else if(isPast)
        {
            screenMR.material.SetTexture("_BaseMap", pastScreen);
            screenMR.material.SetTexture("_EmissionMap", pastScreen);
        }
        else
        {
            Debug.Log("이상한 렌더 텍스쳐 적용중");
        }
    }
}
