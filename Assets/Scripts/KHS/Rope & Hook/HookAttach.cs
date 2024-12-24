using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HookAttach : MonoBehaviour
{
    [SerializeField]
    private Vector3 noRopePos = Vector3.zero;
    [SerializeField]
    private Vector3 onRopePos = Vector3.zero;
    [SerializeField]
    private float lerpratio = 0.003f;
    [SerializeField]
    private Rope ropeGo = null;

    private bool isArrived = false;

    public delegate void HookAttachDelegate();
    private HookAttachDelegate hookAttachCallback = null;

    public HookAttachDelegate HookAttachCallback
    {
        get { return hookAttachCallback; }
        set { hookAttachCallback = value; }
    }
    private void Awake()
    {
        ropeGo = GetComponentInChildren<Rope>();
    }

    private void Start()
    {
        transform.localPosition = noRopePos;
        onRopePos = noRopePos + 5*Vector3.up;
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.name == "ChainLink")
        {
            Debug.Log("Rope Attact!");
            hookAttachCallback?.Invoke();
            StartCoroutine(StayPositionMove());
        }
    }

    private IEnumerator StayPositionMove()
    {
        yield return new WaitForSeconds(0.5f);
        while(!isArrived)
        {
            if((transform.localPosition - onRopePos).magnitude <= 0.1f)
            {
                isArrived = true;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, onRopePos, lerpratio);
                yield return null;
            }
        }
        Debug.Log("Arrived!");
    }
}
