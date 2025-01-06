using UnityEngine;

public class bookManager : MonoBehaviour
{
    public bool isSuccess;
    private BookCheckPoint[] bookCheckPoints = null;

    public delegate void OnAnimationDelegate();
    public OnAnimationDelegate onAniamtionCallback = null;

    private void Awake()
    {
        bookCheckPoints = GetComponentsInChildren<BookCheckPoint>();
       
    }

    private void Start()
    {
        foreach (BookCheckPoint bookCheckPoint in bookCheckPoints)
            bookCheckPoint.onCheckedCallback = OnCheckedCallback;
    }

    private void OnCheckedCallback()
    {
        isSuccess = true;
        foreach (BookCheckPoint bookCheckPoint in bookCheckPoints)
        {
            if (bookCheckPoint.isChecked == false)
            {
                isSuccess = false;
                break;
            }
        }

        if (isSuccess)
        {
            // 성공
            Debug.Log("성공");
            //Invoke("MovigBookSelf", 2f);
            onAniamtionCallback?.Invoke();
            Destroy(this.gameObject, 10f);

        }
        else
        {
            // 실패
        }
    }
}
