using UnityEngine;

public class TypingArea : MonoBehaviour
{

    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftTypingHand;
    public GameObject RightTypingHand;


    //private void OnTriggerEnter(Collider other)
    //{
    //    GameObject hand = other.GetComponentInparent<OVRGrabber>().gameobject;
    //    if (hand == null) return;
    //    if (hand == LeftHand)
    //    {
    //        LeftTypingHand.SetActive(true);

    //    }
    //    else if (hand == RightHand)
    //    {
    //        RightTypingHand.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    GameObject hand = other.GetComponentInparent<OVRGrabber>().gameobject;
    //    if (hand == null) return;
    //    if (hand == LeftHand)
    //    {
    //        LeftTypingHand.SetActive(false);

    //    }
    //    else if (hand == RightHand)
    //    {
    //        RightTypingHand.SetActive(false);
    //    }
    //}

}
