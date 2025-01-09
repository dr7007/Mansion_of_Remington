using UnityEngine;

public class MirrorP : MonoBehaviour
{

    //위치로 인식해서 맞는 위치에 배치했을 때 다른 공간 생기게 되고 그 안에 버튼 있고 
    //동시 누르면 정답으로 처리 
    //배치한 뒤 1초 2초의 시간 가격을 줘야 함 
    //위치 인식 - 매칭하는 것  - 타겟 & Trigger   
    //맞는 위치에 두면 mirror & backPan 비활성화 된다.

    public delegate void MirroDelegate();
    public MirroDelegate mirroSucessCallback;


    [SerializeField] private GameObject Mirror;
    [SerializeField] private GameObject MirrorBackpan;
    [SerializeField] private GameObject Wall;

    [SerializeField] private MirrorButtonController mirrorbutton;
    [SerializeField] private MirroInsideButtonController mirrorinsidebutton;

    public bool TheResult = false;

    private void Update()
    {
        if (mirrorbutton.TheButtonisPressed == true && mirrorinsidebutton.TheButtonisPressed == true && !TheResult)
        {
            Debug.Log("동시 눌렀다");
            TheResult = true;
            mirroSucessCallback?.Invoke();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TheMirrorPlace")
        {
            //Debug.Log("작동");

            Mirror.SetActive(false);
            MirrorBackpan.SetActive(false);
            Wall.SetActive(false);

            //Invoke("Mirror.SetActive(false)", 1f);
            //Invoke("Mirrorbackpan.SetActive(false)", 1f);
            //Invoke("Wall.SetActive(false)", 1f);

        }
    }


}
