using UnityEngine;

public class BongController : MonoBehaviour
{

    public bool TheBongOnTouch = false;


    private void OnTriggerEnter(Collider other)
    {
        TheBongOnTouch = true;
    }

}
