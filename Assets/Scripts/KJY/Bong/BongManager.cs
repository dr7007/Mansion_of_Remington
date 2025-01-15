using UnityEngine;

public class BongManager : MonoBehaviour
{
    [SerializeField] private BongController bongcontroller;
    [SerializeField] private PictureBongController picturebongcontroller;
    [SerializeField] private GameObject BongPlane;
    [SerializeField] private GameObject BongTagPlace;
    [SerializeField] private GameObject BongPicture;

    public bool TheResult = false;

    [SerializeField] private GameObject Fuse;

    private void Update()
    {
        if(TheResult == false)
        {
            if(bongcontroller.TheBongOnTouch == true && picturebongcontroller.TheBongOnTouch == true)
            {
                TheResult = true;
                Fuse.SetActive(true);
                Debug.Log("µøΩ√ ¡¢√À");
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BongTagPlace")
        {
            BongPlane.SetActive(false);
            BongPicture.SetActive(false);
            BongTagPlace.SetActive(false);
        }
    }

}
