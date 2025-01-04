using UnityEngine;
using Photon.Pun;

public class LockInteraction : MonoBehaviourPun
{
    public delegate void LockOpenDelegate();
    public LockOpenDelegate LockOpenCallback;

    public void Interaction()
    {
        // 자물쇠 open
        Transform childTransform = transform.GetChild(0);
        childTransform.localPosition = childTransform.localPosition + new Vector3(0f, 0.02f, 0f);
        // photonView.RPC("InteractionRPC", RpcTarget.Others);
    }

    [PunRPC]
    private void InteractionRPC()
    {
        // 소년의 움직임이 활성화 되도록 하는 어떤 기능이 들어가야함.
        LockOpenCallback?.Invoke();
    }
}
