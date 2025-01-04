using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShakeSomething : MonoBehaviour
{

    //오브젝트
    public XRGrabInteractable grabInteractable;

    //흔들림의 임계값
    [SerializeField] private float ShakeValue;

    //체크 시간
    [SerializeField] private float ShakeDuration;

    //양손의 포지션
    private Vector3 previousLeftHandPosition;
    private Vector3 previousRightHandPosition;

    //양손 잡고 있는 상태
    private bool isGrabbedWithTwoHands = false;

    //흔들림의 강도
    private float ShakeIntensity = 0f;


    private void Start()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void Update()
    {
        if (isGrabbedWithTwoHands)
        {
            Vector3 currentLeftHandPosition = grabInteractable.interactorsSelecting[0].transform.position;
            Vector3 currentRightHandPosition = grabInteractable.interactorsSelecting[1].transform.position;

            // 양 손의 움직임 차이를 기반으로 흔들림 계산
            float leftHandShake = Vector3.Distance(currentLeftHandPosition, previousLeftHandPosition);
            float rightHandShake = Vector3.Distance(currentRightHandPosition, previousRightHandPosition);

            ShakeIntensity += leftHandShake + rightHandShake;

            // 이전 손 위치 갱신
            previousLeftHandPosition = currentLeftHandPosition;
            previousRightHandPosition = currentRightHandPosition;

            // 흔들림 강도가 임계값을 초과하면 공 떨어뜨리기
            if (ShakeIntensity > ShakeValue)
            {
                TheKeyAnswer();
                ShakeIntensity = 0f; // 초기화
            }
        }
    }

    private void OnRelease(SelectExitEventArgs arg0)
    {
        if (grabInteractable.interactorsSelecting.Count < 2) // 손을 놓았을 때
        {
            isGrabbedWithTwoHands = false;
            ShakeIntensity = 0f; // 흔들림 초기화
        }
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        if (grabInteractable.interactorsSelecting.Count == 2) // 양손으로 잡았을 때
        {
            isGrabbedWithTwoHands = true;

            // 초기 위치 설정
            previousLeftHandPosition = grabInteractable.interactorsSelecting[0].transform.position;
            previousRightHandPosition = grabInteractable.interactorsSelecting[1].transform.position;

            ShakeIntensity = 0f; // 흔들림 초기화
        }
    }

    public void TheKeyAnswer()
    {
        GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Sphere.transform.localPosition = new Vector3(0, 1, 2);
        Sphere.AddComponent<Rigidbody>();

    }


}
