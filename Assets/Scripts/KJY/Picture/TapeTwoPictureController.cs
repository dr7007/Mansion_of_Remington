using UnityEngine;

public class TapeTwoPictureController : MonoBehaviour
{
    [SerializeField] private GameObject TapeTwoPlane;
    [SerializeField] private GameObject TapeTwoPicture;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TapeOneTagPlace")
        {
            TapeTwoPlane.SetActive(false);
            TapeTwoPicture.SetActive(false);
        }
    }
}
