using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class Cube1LeversController : MonoBehaviour
{

    public Transform leverBase; // 레버의 기준점
    [SerializeField] private float maxAngle = 80f; 
    [SerializeField] private float minAngle = -80f; 


    public float AngleX = 0f;
    public float AngleY = 0f;

    void Update()
    {
        StartCoroutine(LeverControl());
    }

    //public void OriginRotation()
    //{
    //    transform.localRotation = Quaternion.Euler(0f,0f,0f);
    //}

    public IEnumerator LeverControl()
    {
        if (Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform) // 레버 클릭 여부 확인
                {
                    // 마우스 방향으로 회전 계산
                    Vector3 mousePosition = Input.mousePosition;
                    Vector3 leverPosition = Camera.main.WorldToScreenPoint(transform.position);
                    Vector3 direction = (mousePosition - leverPosition).normalized;

                    // X, Y 축 회전 계산
                    float angleX = Mathf.Clamp(direction.y * maxAngle, minAngle, maxAngle);
                    float angleY = Mathf.Clamp(-direction.x * maxAngle, minAngle, maxAngle);

                    AngleX = angleX;
                    AngleY = angleY;

                    // Z 축은 고정, X, Y 축 회전 적용
                    transform.localRotation = Quaternion.Euler(angleX, angleY, 0);

                }
            }
        }

        yield return null;
    }




}
