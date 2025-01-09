using UnityEngine;

public class SetPCamTr : MonoBehaviour
{
    [SerializeField]
    private GameObject pCam;

    void Start()
    {
        GameObject.Find("PastCamera").GetComponent<TrackingCamera>().pCamTr = pCam.transform;
    }
}
