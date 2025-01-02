using UnityEngine;

public class AttachHand : MonoBehaviour
{
    [SerializeField]
    [Tooltip("손을 붙일 위치")]
    private Transform attachPos;
    [SerializeField]
    [Tooltip("손을 붙일 객체")]
    private GameObject attachGo;

    [Tooltip("손")]
    public GameObject hand = null;

    public bool grapping = false;

    private void Update()
    {
        if (grapping)
        {
            hand.transform.position = attachPos.position;
        }
    }

    // hand를 자식으로 붙임.
    public void SetChildHand()
    {
        hand.transform.SetParent(attachGo.transform);
    }

}
