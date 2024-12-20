using UnityEngine;

public class Cube1LeversController : MonoBehaviour
{

    public Transform LeverBase;

    [SerializeField] private float MaxAngle = 65f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
    
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform == transform)
                {
                    Vector3 direction = hit.point - LeverBase.position;
                    direction = LeverBase.InverseTransformDirection(direction);

                    float angleX = Mathf.Clamp(direction.y * 100f, -MaxAngle, MaxAngle);
                    float angleY = Mathf.Clamp(direction.x * 100f, -MaxAngle, MaxAngle);

                    transform.rotation = Quaternion.Euler(angleX, angleY, 0f);
                    //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, initialRotation, Time.deltaTime * 100f);
                }
                else
                {
                    //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, initialRotation, Time.deltaTime * 100f);
                }
            }
        }

    }

    public Vector2 GetLeverInput()
    {
        float InputX = transform.localRotation.eulerAngles.x;
        float InputY = transform.localRotation.eulerAngles.y;

        //if (InputX > 180) InputX -= 360;
        //if (InputY > 180) InputY -= 360;

        return new Vector2(InputX / MaxAngle, InputY / MaxAngle);
    }





}
