using System.Collections;
using UnityEngine;

public class CheckTheBoyLastDoor : MonoBehaviour
{
    [SerializeField] private GameObject DoorUp;
    [SerializeField] private GameObject DoorMiddle;
    [SerializeField] private GameObject DoorDown;

    [SerializeField] private GameObject DoorPicture1;
    [SerializeField] private GameObject DoorPicture2;
    [SerializeField] private GameObject DoorPicture3;

    [SerializeField] private GameObject RealDoor;

    private FireBurnOutShading realDoorEffect;
    private FireBurnOutShading canvasEffect;
    public FireBurnOutShadingUI[] canvasUIEffects;
    

    [SerializeField]
    private int CurIdx = 0;
    private bool Once = false;

    private void Awake()
    {
        RealDoor.SetActive(true);
        realDoorEffect = RealDoor.GetComponent<FireBurnOutShading>();
        canvasEffect = GetComponent<FireBurnOutShading>();
    }
    private void Start()
    {
        RealDoor.SetActive(false);
    }
    private void Update()
    {
        if(CurIdx == 3 && !Once)
        {
            TrueEndingEffect();
            Once = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door1")
        {
            DoorUp.SetActive(true);
            DoorPicture1.SetActive(false);
            ++CurIdx;
        }
        if(other.gameObject.tag == "Door2")
        {
            DoorMiddle.SetActive(true);
            DoorPicture2.SetActive(false);
            ++CurIdx;
        }
        if(other.gameObject.tag == "Door3")
        {
            DoorDown.SetActive(true);
            DoorPicture3.SetActive(false);
            ++CurIdx;
        }
    }
    private void TrueEndingEffect()
    {
        StartCoroutine(TrueEndingEffectCoroutine());
    }
    private IEnumerator TrueEndingEffectCoroutine()
    {
        RealDoor.SetActive(true);
        yield return null;
        canvasEffect.FireFadeOut();
        realDoorEffect.FireFadeIn();
        foreach(FireBurnOutShadingUI fUI in canvasUIEffects)
        {
            fUI.FireFadeOut();
        }
    }
}
