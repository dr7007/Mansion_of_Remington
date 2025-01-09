using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShakeSomething : MonoBehaviour
{
    // 흔들릴 3D 오브젝트
    public Transform objectToShake;

    [SerializeField] private XRGrabInteractable grab;

    // 떨어질 오브젝트 프리팹
    public GameObject Book;


    // 흔들림 감지 임계값
    public float shakeThreshold = 1.0f;
    // 흔들림 지속 시간
    public float shakeDuration = 1f;
    // 양손 동기화 시간 허용 범위
    public float syncThreshold = 0.2f;

    // 오른손 위치 액션
    public InputActionProperty rightHandPositionAction;
    // 왼손 위치 액션
    public InputActionProperty leftHandPositionAction;

    // 오른손의 이전 위치
    private Vector3 lastRightPosition;
    // 왼손의 이전 위치
    private Vector3 lastLeftPosition;
    private float shakeTimer = 0f;

    private float TheTime = 0f;
    private float timeLimit = 3f;


    void Start()
    {
        lastRightPosition = Vector3.zero;
        lastLeftPosition = Vector3.zero;
    }

    void Update()
    {
        if (grab.isSelected)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            TheTime = 0f;
        }


        // 위치 데이터 가져오기
        Vector3 rightPosition = rightHandPositionAction.action.ReadValue<Vector3>();
        Vector3 leftPosition = leftHandPositionAction.action.ReadValue<Vector3>();

        // 속도 계산
        Vector3 rightVelocity = (rightPosition - lastRightPosition) / Time.deltaTime;
        Vector3 leftVelocity = (leftPosition - lastLeftPosition) / Time.deltaTime;

        // 양손 흔들림 동기화 확인
        if (rightVelocity.magnitude > shakeThreshold && leftVelocity.magnitude > shakeThreshold)
        {
            TheTime += Time.deltaTime;
            // 속도의 시간 차 확인
            float timeDifference = Mathf.Abs(rightVelocity.magnitude - leftVelocity.magnitude);
            if (TheTime >= timeLimit)
            {
                if (timeDifference <= syncThreshold)
                {
                    shakeTimer = shakeDuration;
                    SetActive();
                    //MakePrefabs();
                }

            }
        }

        // 이전 위치 업데이트
        lastRightPosition = rightPosition;
        lastLeftPosition = leftPosition;

        // 흔들림 애니메이션
        if (shakeTimer > 0)
        {
            ShakeObject();
            shakeTimer -= Time.deltaTime;
        }
    }

    void ShakeObject()
    {
        if (objectToShake != null)
        {
            // 흔들림 크기
            float shakeAmount = Mathf.Sin(Time.time * 20) * 0.1f;
            objectToShake.localPosition = new Vector3(shakeAmount, 0, 0);
        }
    }

    void SetActive()
    {

        Book.SetActive(true);

    }
}
