using System.Collections.Generic;
using UnityEngine;

public class MoveRuller : MonoBehaviour
{
    public PadLockPassword lockPassword;

    public List <Transform> rullers = new List<Transform>();
    private int scroolRuller = 0;
    private int changeRuller = 0;
    public int[] numberArray = {0,0,0,0};
    private int numberRuller = 0;
    private bool isActveEmission = false;


    private void Awake()
    {
        rullers.Add(transform.GetChild(0));
        rullers.Add(transform.GetChild(1));
        rullers.Add(transform.GetChild(2));
        rullers.Add(transform.GetChild(3));

        foreach (Transform r in rullers)
        {
            r.transform.Rotate(-144, 0, 0, Space.Self);
        }
    }
    private void Update()
    {
        if (!lockPassword.IsClear)
        {
            MoveRulles();
            RotateRullers();
        }
    }

    // A, D로 움직이고, 해당하는 부분은 반짝임.
    private void MoveRulles()
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            isActveEmission = true;
            changeRuller ++;
            numberRuller += 1;

            if (numberRuller > 3)
            {
                numberRuller = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            isActveEmission = true;
            changeRuller --;
            numberRuller -= 1;

            if (numberRuller < 0)
            {
                numberRuller = 3;
            }
        }
        changeRuller = (changeRuller + rullers.Count) % rullers.Count;

        for (int i = 0; i < rullers.Count; i++)
        {
            if (isActveEmission)
            {
                if (changeRuller == i)
                {

                    rullers[i].gameObject.GetComponent<PadLockEmissionColor>().isSelect = true;
                    rullers[i].gameObject.GetComponent<PadLockEmissionColor>().BlinkingMaterial();
                }
                else
                {
                    rullers[i].gameObject.GetComponent<PadLockEmissionColor>().isSelect = false;
                    rullers[i].gameObject.GetComponent<PadLockEmissionColor>().BlinkingMaterial();
                }
            }
        }

    }

    // W, S로 돌림.
    private void RotateRullers()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isActveEmission = true;
            scroolRuller = 36;
            rullers[changeRuller].Rotate(-scroolRuller, 0, 0, Space.Self);

            numberArray[changeRuller] += 1;

            if (numberArray[changeRuller] > 9)
            {
                numberArray[changeRuller] = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isActveEmission = true;
            scroolRuller = 36;
            rullers[changeRuller].Rotate(scroolRuller, 0, 0, Space.Self);

            numberArray[changeRuller] -= 1;

            if (numberArray[changeRuller] < 0)
            {
                numberArray[changeRuller] = 9;
            }
        }
    }
}
