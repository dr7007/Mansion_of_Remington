using UnityEngine;

public class GCondition : MonoBehaviour
{
    public delegate void JudgeSolvedCondition(bool _state);

    private JudgeSolvedCondition onSolvedCallback = null;

    public JudgeSolvedCondition OnSolvedCallback
    {
        get { return onSolvedCallback; }
        set { onSolvedCallback = value; }
    }

    public void OnSolved(bool _isSolved)
    {
        OnSolvedCallback?.Invoke(_isSolved);
    }
}
