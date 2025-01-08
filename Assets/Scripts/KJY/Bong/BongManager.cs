using UnityEngine;

public class BongManager : MonoBehaviour
{
    [SerializeField] private BongController bongcontroller;
    [SerializeField] private PictureBongController picturebongcontroller;

    public bool TheResult = false;

    private void Update()
    {
        if(TheResult == false)
        {
            if(bongcontroller.TheBongOnTouch == true && picturebongcontroller.TheBongOnTouch == true)
            {
                TheResult = true;
                Debug.Log("µøΩ√ ¡¢√À");
            }
        }
        
    }

}
