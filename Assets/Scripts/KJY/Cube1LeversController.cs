using UnityEngine;

public class Cube1LeversController : MonoBehaviour
{

    public Transform LeverBase;


    //제한 각도
    [SerializeField] private float MaxAngle = 65f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;


    private float Speed = 3f;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
    
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform == transform)
                {
                   
                        Vector3 targetpoint = hit.transform.position;
                        Vector3 direction = targetpoint - LeverBase.position;
                        direction = Vector3.Normalize(direction);
                        
                        float angleX = Mathf.Clamp(direction.y * 100f, -MaxAngle, MaxAngle);
                        float angleY = Mathf.Clamp(direction.x * 100f, -MaxAngle, MaxAngle);

                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleX, angleY, 0f), Time.deltaTime * Speed);

                    



                }
            }
        }

    }







}
