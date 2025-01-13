using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChainReset : MonoBehaviour
{
    public List<Rigidbody> chainLinks; // 체인을 구성하는 Rigidbody 배열
    public Vector3[] initialPositions; // 초기 위치 저장
    public Quaternion[] initialRotations; // 초기 회전 저장
    public HookAttach hookAttach;

    private void Awake()
    {
        chainLinks = GetComponentsInChildren<Rigidbody>().ToList();
        chainLinks.RemoveAt(0);
    }
    void Start()
    {
        // 초기 위치와 회전 값 저장
        initialPositions = new Vector3[chainLinks.Count];
        initialRotations = new Quaternion[chainLinks.Count];
        hookAttach.HookArrivedCallback += RecordInitialize;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            ResetChainPhysics();
        }
    }

    private void RecordInitialize()
    {
        Debug.Log("타란!");
        for (int i = 0; i < chainLinks.Count; i++)
        {
            // Rigidbody의 위치와 회전 초기화
            initialPositions[i] = chainLinks[i].transform.position;
            initialRotations[i] = chainLinks[i].transform.rotation;
        }
    }
    public void ResetChainPhysics()
    {
        Debug.Log("초기화 진입");
        foreach(Rigidbody rb in chainLinks)
        {
            rb.isKinematic = true;
        }
        for (int i = 0; i < chainLinks.Count; i++)
        {
            // Rigidbody의 위치와 회전 초기화
            chainLinks[i].transform.position = initialPositions[i];
            chainLinks[i].transform.rotation = initialRotations[i];

            chainLinks[i].isKinematic = false;
            // 물리 상태 초기화
            chainLinks[i].linearVelocity = Vector3.zero;
            chainLinks[i].angularVelocity = Vector3.zero;
        }
    }
}