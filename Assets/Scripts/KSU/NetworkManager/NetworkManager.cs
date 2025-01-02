using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    [Header("플레이어 콜백 뿌리는 쪽")]
    [SerializeField]
    [Tooltip("처음 자물쇠 풀렸을때 콜백")]
    private LockInteraction openLock;
    [SerializeField]
    [Tooltip("기자가 누른 동물버튼 콜백")]
    private AnimalBoard wAnimalboard;

    [Header("플레이어 콜백 받는 쪽")]
    [SerializeField]
    [Tooltip("동물버튼 콜백을 받는 소년큐브2면")]
    private Cube2Sound bAnimalboard;

    private void Start()
    {
        openLock.LockOpenCallback += BoyMoveOn;
        wAnimalboard.animalBtnCallback += WCallbackAnimal;
    }

    private void BoyMoveOn()
    {
        // 소년이 움직일수 있도록 설정
    }

    private void WCallbackAnimal(string _animal)
    {
        // 소년에게 기자가 누른 버튼의 정보를 넘김.
        if (_animal == "Monkey")
        {
            bAnimalboard.CallbackMonkey();
        }

        if (_animal == "Mouse")
        {
            bAnimalboard.CallbackMouse();
        }
    }
}
