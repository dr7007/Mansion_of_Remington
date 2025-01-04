using UnityEngine;
using System.Collections;

public class glass : MonoBehaviour
{

    public delegate void GlassDelegate(glass _glass);

    private GlassDelegate glassCallback = null;

    public Collider[] colliders;
    parents parents;

    public GlassDelegate GlassCallback
    {
        set { glassCallback = value; }
    }

    private void Awake()
    {
        parents = GetComponent<parents>();

        colliders = GetComponentsInChildren<Collider>();

        foreach(Collider col in colliders)
        {
            col.GetComponent<Renderer>().enabled = false;
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            // 전체 움직임 제한
            rb.constraints = (RigidbodyConstraints)126;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 기존 상태의 유리창 예외처리
            GetComponent<Renderer>().enabled = false;

            foreach (Collider col in colliders)
            {
                // if (col.name == "12") continue;
                col.gameObject.GetComponent<Renderer>().enabled = true;

                Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

                // 전체 움직임 풀어줌
                rb.constraints = (RigidbodyConstraints)0;
            }
        }
    }
}
