using UnityEngine;

public class CheckTheBoyLastDoor : MonoBehaviour
{
    [SerializeField] private GameObject DoorUp;
    [SerializeField] private GameObject DoorMiddle;
    [SerializeField] private GameObject DoorDown;

    [SerializeField] private GameObject DoorPicture1;
    [SerializeField] private GameObject DoorPicture2;
    [SerializeField] private GameObject DoorPicture3;

    [SerializeField] private GameObject RealDoor;

    private int CurIdx = 0;
    private bool Once = false;

    private void Update()
    {
        if(CurIdx == 3 && !Once)
        {
            //¿£µù
            RealDoor.SetActive(true);
            Once = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door1")
        {
            DoorUp.SetActive(true);
            DoorPicture1.SetActive(false);
            ++CurIdx;
        }
        if(other.gameObject.tag == "Door2")
        {
            DoorMiddle.SetActive(true);
            DoorPicture2.SetActive(false);
            ++CurIdx;
        }
        if(other.gameObject.tag == "Door3")
        {
            DoorDown.SetActive(true);
            DoorPicture3.SetActive(false);
            ++CurIdx;
        }
    }

}
