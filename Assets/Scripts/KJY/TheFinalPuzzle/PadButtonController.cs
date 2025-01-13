using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PadButtonController : MonoBehaviour
{

    [SerializeField] private GameObject LastDoor;
    [SerializeField] private GameObject PadPuzzle;
    [SerializeField] private AudioClip audioClips;


    List<string> FinalResult = new List<string> { "L", "A", "S", "T" };
    [SerializeField] private List<string> CurResult1 = new List<string>();

    public bool TheResult = false;

    public Material[] mats;

    private void Start()
    {
    }


    private void Update()
    {


        if (CurResult1.Count == 4)
        {
            foreach (string Cur1 in CurResult1)
            {
                Debug.Log(Cur1);
                CheckTheResult();
            }
        }


    }


    private void CheckTheResult()
    {

        if (CurResult1.SequenceEqual(FinalResult))
        {
            TheResult = true;
            IfCan();
            //Debug.Log("성공");
            //문열리는 소리 나오고 문이 조금 열린다. -> 엔딩
        }
        CurResult1 = new List<string>();
        Invoke("ResetColor", 2f);

    }

    private void IfCan()
    {
        LastDoor.SetActive(true);
        AudioClip Door = audioClips;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(Door, 0.8f);
        PadPuzzle.SetActive(false);
    }

    public void FirstBTN()
    {
        CurResult1.Add("H");
        mats[0].EnableKeyword("_EMISSION");
    }

    public void SecondBTN()
    {
        CurResult1.Add("A");
        mats[1].EnableKeyword("_EMISSION");
    }

    public void ThirdBTN()
    {

        CurResult1.Add("D");
        mats[2].EnableKeyword("_EMISSION");
    }

    public void FourthBTN()
    {

        CurResult1.Add("M");
        mats[3].EnableKeyword("_EMISSION");
    }
    //HADMTYLQS

    public void FifthBTN()
    {

        CurResult1.Add("T");
        mats[4].EnableKeyword("_EMISSION");
    }

    public void SixthBTN()
    {

        CurResult1.Add("Y");
        mats[5].EnableKeyword("_EMISSION");

    }

    public void SeventhBTN()
    {
        CurResult1.Add("L");
        mats[6].EnableKeyword("_EMISSION");
    }

    public void EighthBTN()
    {

        CurResult1.Add("Q");
        mats[7].EnableKeyword("_EMISSION");
    }
    public void NinthBTN()
    {

        CurResult1.Add("S");
        mats[8].EnableKeyword("_EMISSION");
    }

    private void ResetColor()
    {
        foreach(Material mat in mats)
        {
            mat.DisableKeyword("_EMISSION");
        }
    }
}
