using UnityEngine;

public class LockInteraction : MonoBehaviour
{
    public bool IsInteraction = false;
    public GResponse res;

    private void Start()
    {
        res.OnResponseCallback += Interaction;
    }

    private void Interaction(bool _state)
    {
        // ÀÚ¹°¼è open
        Transform childTransform = transform.GetChild(0);
        childTransform.localPosition = childTransform.localPosition + new Vector3(0f, 0.02f, 0f);
    }
}
