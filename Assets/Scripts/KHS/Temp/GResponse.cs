using UnityEngine;

public class GResponse : MonoBehaviour
{
    #region Delegate & Callback
    public delegate void OnResponseDelegate(bool _state);

    private OnResponseDelegate onResponseCallback = null;
    public OnResponseDelegate OnResponseCallback
    {
        get { return onResponseCallback; }
        set { onResponseCallback = value; }
    }
    #endregion

    private ManageSystem manager = null;

    private void Awake()
    {
        manager = FindFirstObjectByType<ManageSystem>();
    }

    public void OnResponse(bool _isSolved)
    {
        OnResponseCallback?.Invoke(_isSolved);
    }




}
