using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShakeFunctionV2 : MonoBehaviour
{
    // 흔들릴 3D 오브젝트
    public Transform objectToShake;

    [SerializeField] private XRGrabInteractable grab;

    // 떨어질 오브젝트 프리팹
    public GameObject Beer;
    public GameObject Shape;
    public GameObject Mouse;
    public GameObject Pig;
    public GameObject Monkey;
    public GameObject Penguin;
    public GameObject Rabbit;


    // 흔들림 감지 임계값
    public float shakeThreshold = 1.5f;

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


    private Vector3 lastRightVeclocity;
    private Vector3 lastLeftVeclocity;

    private Vector3 LeftAccelaretion;
    private Vector3 RightAccelaretion;

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


            // 위치 데이터 가져오기
            Vector3 rightPosition = rightHandPositionAction.action.ReadValue<Vector3>();
            Vector3 leftPosition = leftHandPositionAction.action.ReadValue<Vector3>();

            // 속도 계산
            Vector3 rightVelocity = (rightPosition - lastRightPosition) / Time.deltaTime;
            Vector3 leftVelocity = (leftPosition - lastLeftPosition) / Time.deltaTime;

            LeftAccelaretion = (leftVelocity - lastLeftVeclocity) / Time.deltaTime;
            RightAccelaretion = (rightVelocity - lastRightVeclocity) / Time.deltaTime;

            if(LeftAccelaretion.magnitude >= shakeThreshold && RightAccelaretion.magnitude >= shakeThreshold)
            {
                TheTime += Time.deltaTime;

                float TimeDifference = Mathf.Abs(LeftAccelaretion.magnitude - RightAccelaretion.magnitude);

                if(TheTime >= timeLimit)
                {
                    if(TimeDifference <= syncThreshold)
                    {
                        //흔들림
                        shakeTimer = TheTime;
                        SetActive();
                        
                    }
                }
            }

            TheTime = 0;

            //이전 위치 업데이트
            lastRightPosition = rightPosition;
            lastLeftPosition = leftPosition;

            //이전 속도 업데이트
            lastRightVeclocity = rightVelocity;
            lastLeftVeclocity = leftVelocity;

            if (shakeTimer > 0)
            {
                ShakeObject();
                shakeTimer -= Time.deltaTime;
            }


        }
        else
        {
            TheTime = 0f;
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

        Beer.SetActive(true);
        Shape.SetActive(true);
        Mouse.SetActive(true);
        Pig.SetActive(true);
        Monkey.SetActive(true);
        Penguin.SetActive(true);
        Rabbit.SetActive(true);

    }




}
