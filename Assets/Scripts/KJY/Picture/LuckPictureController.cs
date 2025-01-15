using UnityEngine;

public class LuckPictureController : MonoBehaviour
{
    
    [SerializeField] private GameObject LuckPlane;
    [SerializeField] private GameObject LuckPicture;
    [SerializeField] private GameObject LuckTagPlace;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LuckTagPlace")
        {
            LuckPlane.SetActive(false);
            LuckPicture.SetActive(false);
            LuckTagPlace.SetActive(false);
        }
    }


}
