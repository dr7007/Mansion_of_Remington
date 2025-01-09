using UnityEngine;

public class SetPCamTr : MonoBehaviour
{
    [SerializeField]
    private GameObject pCam;
    [SerializeField]
    private CameraScreen pCameraScreen;
    [SerializeField]
    private PlayerCameraController playercamController;

    private GameObject pastcam;


    void Start()
    {
        pastcam = GameObject.Find("PastCamera");

        pastcam.GetComponent<TrackingCamera>().pCamTr = pCam.transform;
        pastcam.GetComponent<CameraFrustumCollider>().camScreen = pCameraScreen;
        pastcam.GetComponent<CameraFrustumCollider>().playerControl = playercamController;
    }
}
