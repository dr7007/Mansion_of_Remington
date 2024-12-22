using UnityEngine;

public class LockInteraction : MonoBehaviour
{
    public bool IsInteraction = false;

    private void Update()
    {
        if (IsInteraction)
        {
            Interaction();
            IsInteraction = false;
        }
    }

    private void Interaction()
    {
        // ÀÚ¹°¼è open
        Transform childTransform = transform.GetChild(0);
        childTransform.localPosition = childTransform.localPosition + new Vector3(0f, 0.02f, 0f);
    }
}
