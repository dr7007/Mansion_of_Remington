using UnityEngine;

public class ChainJudge : MonoBehaviour
{
    #region
    public delegate void ChainJudgeInDelegate();
    public delegate void ChainJudgeOutDelegate();

    private ChainJudgeInDelegate chainJudgeInCallback;
    private ChainJudgeOutDelegate chainJudgeOutCallback;

    public ChainJudgeInDelegate ChainJudgeInCallback
    {
        get { return chainJudgeInCallback; }
        set { chainJudgeInCallback = value; }
    }
    public ChainJudgeOutDelegate ChainJudgeOutCallback
    {
        get { return chainJudgeOutCallback; }
        set { chainJudgeOutCallback = value; }
    }
    #endregion

    private Vector3 pathVec = Vector3.zero;

    private void OnTriggerEnter(Collider _chrCollider)
    {
        if(_chrCollider.GetComponent<CollisionHandlerWithAngle>())
        {

        }
    }
    private void OnDrawGizmos()
    {
        // 로컬 X축 (빨강)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right);

        // 로컬 Y축 (초록)
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.up);

        // 로컬 Z축 (파랑)
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
