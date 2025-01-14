using UnityEngine;

public class toyBlockPuzzle : MonoBehaviour
{
    [SerializeField]
    Camera cm;

    private GCondition conTrigger;
    private bool isActive = false;
    void Start()
    {
        conTrigger = GetComponent<GCondition>();
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isChacksi() == true)
            {
                Debug.Log("시야 확정");
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
    }

    bool isChacksi()
    {
        float cmYPosition = cm.transform.position.y;
        float cmYRotation = cm.transform.rotation.eulerAngles.y;

        if ((cmYPosition >=1.2f && cmYPosition <= 1.5f) && (cmYRotation >= 25f && cmYRotation <= 37f))
        {
            return true;
        }

        return false;
    }

    public void OnPhoto()
    {
        if(isActive)
        {
            conTrigger.OnSolved(true);
        }
    }
}
