using UnityEngine;

public class TapeOnePictureController : MonoBehaviour
{

    [SerializeField] private GameObject TapeOnePlane;
    [SerializeField] private GameObject TapeOnePicture;
    [SerializeField] private GameObject TapeOneTagPlace;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TapeOneTagPlace")
        {
            TapeOnePlane.SetActive(false);
            TapeOnePicture.SetActive(false);
            TapeOneTagPlace.SetActive(false);
        }
    }

}
