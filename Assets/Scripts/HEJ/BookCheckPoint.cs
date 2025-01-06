using UnityEngine;

public class BookCheckPoint : MonoBehaviour
{
    public string targetTag = string.Empty;
    public bool isChecked = false;

    public delegate void OnCheckedDelegate();
    public OnCheckedDelegate onCheckedCallback = null;
        
    private RaycastHit hit;


    private void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.2f))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);

            if (hit.transform.gameObject.tag == targetTag)
            {
                isChecked = true;

                onCheckedCallback?.Invoke();
                
            }
            else
            {
                isChecked = false;
            }

        }
        
    }

   

  
}
