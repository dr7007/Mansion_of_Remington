using UnityEngine;

public class PictureBongController : MonoBehaviour
{
    public bool TheBongOnTouch = false;


    private void OnTriggerEnter(Collider other)
    {
        TheBongOnTouch = true;
    }
}
