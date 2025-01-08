using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(GResponse))]
public class LockInteraction : MonoBehaviourPun
{
    public delegate void LockOpenDelegate();
    public LockOpenDelegate LockOpenCallback;

    public GameObject CubeInWomanRoom;

    private GResponse result;
    private void Start()
    {
        if (CubeInWomanRoom != null)
        {
            result.OnResponseCallback += SetCubeOn;
        }
    }

    public void Interaction()
    {
        // 자물쇠 open
        Transform childTransform = transform.GetChild(0);
        childTransform.localPosition = childTransform.localPosition + new Vector3(0f, 0.02f, 0f);
        LockOpenCallback?.Invoke();
    }

    // 기자 방에 큐브가 생성되게 하는거
    private void SetCubeOn(bool _state)
    {
        CubeInWomanRoom.SetActive(true);
    }
}
