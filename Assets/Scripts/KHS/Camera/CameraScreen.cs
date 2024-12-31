using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScreen : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer screenMR = null;
    [SerializeField]
    private RenderTexture presentScreen = null;
    [SerializeField]
    private RenderTexture pastScreen = null;
    [SerializeField]
    private InputActionReference xrControllerAction = null;

    private void Awake()
    {
        screenMR = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
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

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("A Pressed");
        ChangeRenderTex();
    }
    private void OnAButtonReleased(InputAction.CallbackContext context)
    {
        Debug.Log("A Released");
    }

    private void ChangeRenderTex()
    {
        if(screenMR.material.GetTexture("_BaseMap") == presentScreen)
        {
            Debug.Log("past");
            screenMR.material.SetTexture("_BaseMap", pastScreen);
            screenMR.material.SetTexture("_EmissionMap", pastScreen);
        }
        else if(screenMR.material.GetTexture("_BaseMap") == pastScreen)
        {
            Debug.Log("Current");
            screenMR.material.SetTexture("_BaseMap", presentScreen);
            screenMR.material.SetTexture("_EmissionMap", presentScreen);
        }
        else
        {
            Debug.Log("이상한 렌더 텍스쳐 적용중");
        }
    }
}
