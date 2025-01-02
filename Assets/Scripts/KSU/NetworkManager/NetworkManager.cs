using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    [SerializeField]
    private LockInteraction openLock;

    private void Start()
    {
        openLock.LockOpenCallback += BoyMoveOn;
    }

    private void BoyMoveOn()
    {
        // 소년이 움직일수 있도록 설정
    }
}
