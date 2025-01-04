using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerTr =null;
    [SerializeField]
    private Transform tCamTr = null;


    [SerializeField]
    private Vector3 originMap = Vector3.zero;
    [SerializeField]
    private Vector3 targetMap = Vector3.zero;
    private Vector3 offsetMap = Vector3.zero;

    private void Start()
    {
        offsetMap = targetMap - originMap;
        tCamTr.position = playerTr.position + offsetMap;
        tCamTr.rotation = playerTr.rotation;
    }
    private void FixedUpdate()
    {
        tCamTr.position = playerTr.position + offsetMap;
        tCamTr.rotation = playerTr.rotation;
    }
}
