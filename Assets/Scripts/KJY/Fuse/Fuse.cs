using UnityEngine;
using UnityEngine.UI;

public class Fuse : MonoBehaviour
{

    [SerializeField] private GameObject fuse1;
   // [SerializeField] private GameObject fuse1_2;
    [SerializeField] private GameObject fuse1_1;
    [SerializeField] private GameObject TheLight;
    //[SerializeField] private GameObject TheOriginLight;

    [SerializeField] private GameObject TheDeractionObject;
    [SerializeField] private GameObject TheDoorPicture;
    //[SerializeField] private GameObject TheButton;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="FusePlace")
        {
            
            fuse1.SetActive(false);
            fuse1_1.SetActive(true);
            TheDeractionObject.SetActive(true);
            TheDoorPicture.SetActive(true);

            TheLight.SetActive(true);
            //TheButton.SetActive(true);
            //TheOriginLight.SetActive(false);

        }
    }


    public void TheLightCan()
    {
        //TheLight.SetActive(true);
        Debug.Log("Light");
    }


}
