using JetBrains.Annotations;
using UnityEngine;

public class GlassClick : MonoBehaviour
{
    public delegate void OnGlassClickDelegate();

    private OnGlassClickDelegate onGlassClickCallback = null;


    public OnGlassClickDelegate OnGlassClickCallback
    {
        set { onGlassClickCallback = value; }
    }


    public void OnClickProcess()
    {
        onGlassClickCallback?.Invoke();
    }

    public void OnMouseDown()
    {
        OnClickProcess();
    }
}
