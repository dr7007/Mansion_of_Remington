using System.Collections.Generic;
using UnityEngine;

public class ManageSystem : MonoBehaviour
{
    public delegate void RequestDeleagate();

    private RequestDeleagate doResponseCallback = null;
    public RequestDeleagate DoResonseCallback
    {
        get { return doResponseCallback; }
        set { doResponseCallback = value; }
    }

    public List<GCondition> gConList = null;

    public List<GResponse> gResList = null;

    private int i = 0;

    private void Start()
    {
        foreach(GCondition condition in gConList)
        {
            condition.OnSolvedCallback = gResList[i].OnResponse;
            ++i;
        }
        i = 0;
    }

}
