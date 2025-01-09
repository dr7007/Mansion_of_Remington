using UnityEngine;

[RequireComponent(typeof(GResponse))]
public class WomanDoorLockOff : MonoBehaviour
{
    public GameObject WomanTutoriialDoor;
    private GResponse result;

    private void Awake()
    {
       result = GetComponent<GResponse>();
    }

    private void Start()
    {
        result.OnResponseCallback += DoorLockOff;
    }

    private void DoorLockOff(bool _state)
    {
        WomanTutoriialDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        WomanTutoriialDoor.GetComponent<Rigidbody>().isKinematic = false;
    }
}
