using UnityEngine;

public class PadInteraction : MonoBehaviour
{
    public delegate void PadInteractionCallback(string _name);
    public PadInteractionCallback padCallback;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // ÁÂÅ¬¸¯ (0 = ¿ÞÂÊ ¹öÆ°)
        {
            Interaction();
        }
    }

    private void Interaction()
    {
        padCallback?.Invoke(gameObject.name);
    }
}
