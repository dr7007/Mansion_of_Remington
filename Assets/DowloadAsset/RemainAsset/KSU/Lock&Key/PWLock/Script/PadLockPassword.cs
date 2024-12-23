using System.Linq;
using UnityEngine;
using System.Collections;

// 
public class PadLockPassword : MonoBehaviour
{
    public MoveRuller moveRull;
    public int[] numberPassword = {0,0,0,0};
    public bool IsClear = false;
    public GameObject ring;
    public float OpenTime;

    private void Update()
    {
        if (moveRull.numberArray.SequenceEqual(numberPassword))
        {
            PasswordCorrect();
            numberPassword = new int[]{-1, -1, -1, -1 };
        }
    }

    private void PasswordCorrect()
    {
        IsClear = true;

        // 패스워드 일치시
        Debug.Log("Password correct");

        // 더이상 안반짝이게
        for (int i = 0; i < moveRull.rullers.Count; i++)
        {
            moveRull.rullers[i].gameObject.GetComponent<PadLockEmissionColor>().isSelect = false;
            moveRull.rullers[i].gameObject.GetComponent<PadLockEmissionColor>().BlinkingMaterial();
        }

        StartCoroutine(RotateRing());
    }

    private IEnumerator RotateRing()
    {
        float elapseTime = 0f;

        while (elapseTime < OpenTime)
        {
            elapseTime += Time.deltaTime;

            ring.transform.Rotate(0f, 180f * (Time.deltaTime / OpenTime), 0f);
            yield return null;
        }


    }
}
