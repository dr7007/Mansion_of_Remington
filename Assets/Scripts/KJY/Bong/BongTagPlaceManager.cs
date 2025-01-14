using UnityEngine;

public class BongTagPlaceManager : MonoBehaviour
{

    public bool TheResult = false;
    [SerializeField] private BongController bongcontroller;
    [SerializeField] private PictureBongController picturebongcontroller;
    [SerializeField] private GameObject Fuse;

    private void Update()
    {
        if (TheResult == false)
        {
            if (bongcontroller.TheBongOnTouch == true && picturebongcontroller.TheBongOnTouch == true)
            {
                TheResult = true;
                Fuse.SetActive(true);
                Debug.Log("µøΩ√ ¡¢√À");
            }
        }

    }
}
