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
        parentTr.SetParent(hook.transform);
        parentTr.localPosition = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
