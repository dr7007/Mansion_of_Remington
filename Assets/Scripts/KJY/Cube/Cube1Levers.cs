using System.Collections;
using UnityEngine;

public class Cube1Levers : MonoBehaviour
{

    public Cube1LeversController[] levers; // 4개의 레버 연결

    private float[] leverXValues;
    private float[] leverYValues;

    private int curindex0 = 0;
    private int curindex1 = 0;
    private int curindex2 = 0;
    private int curindex3 = 0;

    //정답
    public bool TheLeverResult = false;

    private void Start()
    {
        leverXValues = new float[4];
        leverYValues = new float[4];
    }


    private void Update()
    {
        StartCoroutine(SaveTheValue());

    }


    private IEnumerator SaveTheValue()
    {
        Debug.Log("LeversLength" + levers.Length.ToString());
        for (int i = 0; i < levers.Length; i++)
        {
            leverXValues[i] = levers[i].AngleX;
            leverYValues[i] = levers[i].AngleY;
        }
        WhenTheValueChanged();

        yield return null;

    }

    private void WhenTheValueChanged()
    {
        Debug.Log("Xlength "+ leverXValues.Length.ToString());
        if (leverXValues[3] != 0f)
        {
            Debug.Log("1. " + leverXValues[0]);
            Debug.Log("2. " + leverXValues[1]);
            Debug.Log("3. " + leverYValues[2]);
            Debug.Log("4. " + leverYValues[3]);
            Invoke("CheckTheResult", 3f);
        }
    }


    //상 : x == 60 ~ 65 
    //하 : x == -60 ~ -65
    //좌 : y == 60 ~ 65
    //우 : y == -60 ~ -65
    //상좌 : x,y  == 35 ~ 45
    //상우 : x == 35 ~ 45 , y == -65 ~ -75
    //하좌 : x == -35 ~ -45, y == 35 ~ 45
    //하우 : x == -35 ~ -45, y == -65 ~ -75

    //정답 상 하 좌 우 
    private void CheckTheResult()
    {
        Debug.Log("여기까지");
        if (leverXValues[0] >= 60f && leverXValues[0] <= 65f) curindex0 = 1;
        if (leverXValues[1] <= -60f && leverXValues[1] >= -65f) curindex1 = 1;
        if (leverYValues[2] <= -60f && leverYValues[2] >= -65f) curindex2 = 1;
        if (leverYValues[3] >= 60f && leverYValues[3] <= 65f) curindex3 = 1;
        Debug.Log("CurIndex0 : " + curindex0);
        Debug.Log("CurIndex1 : " + curindex1);
        Debug.Log("CurIndex2 : " + curindex2);
        Debug.Log("CurIndex3 : " + curindex3);
        if(curindex0 == 1 && curindex1 == 1 && curindex2 == 1 && curindex3 == 1)
        {
            Debug.Log("정답");
            TheLeverResult = true;

            Debug.Log("TheLeverResult " + TheLeverResult);
            //레버 움직이지 못하게 막는다.
            StopCoroutine(SaveTheValue());


            //StopCoroutine(levers[0].LeverControl());
            //StopCoroutine(levers[1].LeverControl());
            //StopCoroutine(levers[2].LeverControl());
            //StopCoroutine(levers[3].LeverControl());
            
        }


    }

}
