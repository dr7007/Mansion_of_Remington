using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("자물쇠가 열리는 각도")]
    private float openAngle;
    [SerializeField]
    [Tooltip("회전할 key의 Transform")]
    private Transform keyTr;
    [SerializeField]
    [Tooltip("열릴 자물쇠")]
    private GameObject lockGo;


    public bool inserted = false; // 키가 꽂혀 있는지 여부
    private bool opend = false; // 

    private void Update()
    {
        if (inserted)
        {
            if (keyTr.rotation.y <= openAngle && !opend)
            {
                opend = true;
                lockGo.GetComponent<LockInteraction>().Interaction();
            }
        }
    }
}
