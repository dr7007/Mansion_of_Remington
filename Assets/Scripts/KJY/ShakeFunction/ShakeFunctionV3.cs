using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShakeFunctionV3 : MonoBehaviour
{

    [SerializeField] private XRGrabInteractable grab;
    [SerializeField] private Transform objectToShake;

    // 흔들림을 감지하는 가속도 임계값 (m/s²)
    public float shakeThreshold = 2.0f; 

    // 떨어질 오브젝트 프리팹
    public GameObject Bear;
    public GameObject Sheep;
    public GameObject Mouse;
    public GameObject Pig;
    public GameObject Monkey;
    public GameObject Penguin;
    public GameObject Rabbit;

    private float shakeTimer = 0f;
    private float TheTime = 0f;
    private float timeLimit = 3f;


    private void Update()
    {
        if(grab.isSelected)
        {

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);


            // XR 노드 상태 리스트
            List<XRNodeState> nodeStates = new List<XRNodeState>();
            InputTracking.GetNodeStates(nodeStates);

            Vector3 leftHandAcceleration = Vector3.zero;
            Vector3 rightHandAcceleration = Vector3.zero;

            bool leftHandShaking = false;
            bool rightHandShaking = false;

            // 모든 노드 상태 확인
            foreach (XRNodeState nodeState in nodeStates)
            {
                // 왼쪽 조이스틱의 가속도 확인
                if (nodeState.nodeType == XRNode.LeftHand && nodeState.TryGetAcceleration(out leftHandAcceleration))
                {
                    if (leftHandAcceleration.magnitude > shakeThreshold)
                    {
                        leftHandShaking = true;
                    }
                }

                // 오른쪽 조이스틱의 가속도 확인
                if (nodeState.nodeType == XRNode.RightHand && nodeState.TryGetAcceleration(out rightHandAcceleration))
                {
                    if (rightHandAcceleration.magnitude > shakeThreshold)
                    {
                        rightHandShaking = true;
                    }
                }
            }

            // 양쪽 흔들림 감지
            if (leftHandShaking && rightHandShaking)
            {
                TheTime += Time.deltaTime;
                if(TheTime >= timeLimit)
                {
                    shakeTimer = TheTime;
                    //HandleShakeEvent();
                    HandleShakeEvent(leftHandAcceleration, rightHandAcceleration);
                
                }
            }

            if (shakeTimer > 0)
            {
                ShakeObject();
                shakeTimer -= Time.deltaTime;
            }

            TheTime = 0f;
        }

    }

    // 흔들림 이벤트 처리
    //private void HandleShakeEvent()
    private void HandleShakeEvent(Vector3 leftAcceleration, Vector3 rightAcceleration)
    {
        // 원하는 동작 수행
        Debug.Log($"Shake Detected! Left: {leftAcceleration}, Right: {rightAcceleration}");
        SetActive();
    }

    private void ShakeObject()
    {
        if (objectToShake != null)
        {
            // 흔들림 크기
            float shakeAmount = Mathf.Sin(Time.time * 20) * 0.1f;
            objectToShake.localPosition = new Vector3(shakeAmount, 0, 0);
        }
    }

    private void SetActive()
    {

        Bear.SetActive(true);
        Sheep.SetActive(true);
        Mouse.SetActive(true);
        Pig.SetActive(true);
        Monkey.SetActive(true);
        Penguin.SetActive(true);
        Rabbit.SetActive(true);
    }

}
