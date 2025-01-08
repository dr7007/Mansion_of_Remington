using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PictureBongController : MonoBehaviour
{
    public bool TheBongOnTouch = false;
    private XRGrabInteractable grab;
    private void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        if (grab.isSelected == true)
        {
            TheBongOnTouch = true;
        }
        else
        {
            TheBongOnTouch = false;
        }
    }
}
