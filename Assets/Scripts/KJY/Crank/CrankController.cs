using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CrankController : XRBaseInteractable
{

    //두 장치 위치
    public Transform LeftDeviceTr;
    public Transform RightDeviceTr;

    public XRGrabInteractable grab;

    //손잡이 위치
    public Transform originTr;

    //Door
    [SerializeField] private GameObject Door;
    //Fuse
    //[SerializeField] private GameObject Fuse;

    [SerializeField] private Vector3 DeviceLTrs;
    [SerializeField] private Vector3 DeviceRTrs;

    //초기 각도
    private float OriginAngle = 0f;
    //현재 각도
    private float CurAngle = 0f;
    //총 각도
    private float TotalAngle = 0f;
    //총 바퀴 수
    private int curCnt = 0;

    //현재 장치의 이름
    private string DeviceName;
    [SerializeField] private DoorAnimation doorAni;
    
    
    private void Start()
    {
        grab.selectEntered.AddListener(OnSelectEntered);
    }
    private void Update()
    {
        if (grab.isSelected == true)
        {
            //Debug.Log("left : " + (LeftDeviceTr.position - originTr.position).magnitude);
            //if((LeftDeviceTr.position - originTr.position).magnitude >= 0.25f)
            //{
            //    grab.enabled = false;
            //    grab.enabled = true;
            //}
            TheRange();
            TheRotate();
        }


        if(curCnt < 3)
        {
            TheRotateCnt();
        }
        else if(curCnt == 3 )
        {
            Debug.Log("3바퀴 돌렸다.");
            //Fuse.SetActive(true);
            Door.SetActive(true);
            doorAni.SartDoorAnimation();
        }
    }

    private void TheRotate()
    {
        DeviceLTrs = LeftDeviceTr.transform.position;
        DeviceRTrs = RightDeviceTr.transform.position;
        Vector3 CrankDir = new Vector3();

        //장치 구분
        if(DeviceName == "Left Controller (UnityEngine.Transform)")
        {
            CrankDir = DeviceLTrs - transform.position;
        }
        else if(DeviceName == "Right Controller (UnityEngine.Transform)")
        {
            CrankDir = DeviceRTrs - transform.position;
        }
        
        float z = Mathf.Atan2(CrankDir.y, CrankDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,z + 90f);
    }


    private void TheRotateCnt()
    {
        CurAngle = transform.rotation.eulerAngles.z;


        float angle = OriginAngle - CurAngle;

        if(angle < 0)
        {
            angle = 0;
        }
        
        //누적 Z축 회전 각도 업데이트
        TotalAngle += angle;

        //전체 회전 바퀴 수 계산
        curCnt = Mathf.FloorToInt(TotalAngle / 360f);

        //현재 각도를 이전 각도로 업데이트
        OriginAngle = CurAngle;
    }

    private void TheRange()
    {
        if (DeviceName == "Left Controller (UnityEngine.Transform)")
        {
            if ((LeftDeviceTr.position - originTr.position).magnitude >= 0.25f)
            {
                grab.enabled = false;
                grab.enabled = true;
            }
        }
        else if(DeviceName == "Right Controller (UnityEngine.Transform)")
        {
            if ((RightDeviceTr.position - originTr.position).magnitude >= 0.25f)
            {
                grab.enabled = false;
                grab.enabled = true;
            }
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args); // XRBaseInteractable 기본 동작 유지
        DeviceName = args.interactorObject.transform.parent.ToString();
        Debug.Log("DeviceName : " + DeviceName);
        //Debug.Log($"Object grabbed by: {args.interactorObject.transform.parent}");
    }



}


