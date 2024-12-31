using System.Collections;
using UnityEngine;

public class AnimalBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject rotateGo; // 돌릴 장치
    [SerializeField]
    private float rotateTime; // 돌리는데 걸리는 시간

    private GResponse res;


    private void Awake()
    {
        res = GetComponent<GResponse>();
    }

    private void Start()
    {
        res.OnResponseCallback += Interaction;
    }


    // 동물 석상 장치를 풀었을때 발생하는 함수
    private void Interaction(bool _state)
    {
        // 장치가 돌아가도록?
        // rotateGo.transform.Rotate(0f, 0f, 180f);
        StartCoroutine(RotateGoCoroutine());
    }

    // 1초동안 180도 돌림
    private IEnumerator RotateGoCoroutine()
    {
        float elapseTime = 0f;

        while (elapseTime < rotateTime)
        {
            elapseTime += Time.deltaTime;

            rotateGo.transform.Rotate(0f, 0f, 180f * (rotateTime * Time.deltaTime));

            yield return null;
        }
    }
}
