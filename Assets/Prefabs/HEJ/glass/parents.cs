using UnityEngine;

public class parents : MonoBehaviour
{
    private Rigidbody[] rbs = null;
    private GlassClick glassClick = null;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        glassClick = GetComponentInChildren<GlassClick>();
        glassClick.OnGlassClickCallback = OnGlassClickCallback;
    }
    private void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

   
    private void OnKinematicAll(bool _isOn)
    {
        foreach (Rigidbody rb in rbs)
            rb.isKinematic = _isOn;
    }

    private void OnGlassClickCallback()
    {
        OnKinematicAll(false);
    }
}
