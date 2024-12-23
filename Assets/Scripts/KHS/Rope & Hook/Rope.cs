using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Rope : MonoBehaviour
{
    private XRGrabInteractable grabinter = null;
    private Rigidbody rb = null;
    private HookAttach hook = null;
    private Transform parentTr = null;
    


    private void Awake()
    {
        hook = FindAnyObjectByType<HookAttach>();
        rb = GetComponent<Rigidbody>();
        grabinter = GetComponent<XRGrabInteractable>();
        parentTr = transform.parent;
    }
    private void Start()
    {
        hook.HookAttachCallback = SetAttach;
        
    }

    private void SetAttach()
    {
        rb.isKinematic = true;
        grabinter.enabled = false;
        parentTr.position = hook.transform.position;
        gameObject.transform.position = hook.transform.position - 0.4f * Vector3.up;
        gameObject.transform.rotation = Quaternion.identity;
        parentTr.SetParent(hook.transform);
    }
}
