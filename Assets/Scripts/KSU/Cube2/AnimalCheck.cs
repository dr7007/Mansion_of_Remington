using UnityEngine;

public class AnimalCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject monkeyPos;
    [SerializeField]
    private GameObject pigPos;
    [SerializeField]
    private GameObject board;

    private PushAndPull monkey;
    private PushAndPull pig;
    private bool activeOnce = false;

    private GCondition solve;

    private void Start()
    {
        monkey = monkeyPos.GetComponent<PushAndPull>();
        pig = pigPos.GetComponent<PushAndPull>();
        solve = GetComponent<GCondition>();
    }

    private void Update()
    {
        if(!activeOnce)
        {
            if (monkey.curGO == null || pig.curGO == null) return;

            if (monkey.curGO.name == "MONKEY" && pig.curGO.name == "PIG")
            {
                activeOnce = true;

                // 뭔가 이벤트가 일어나도록?
                solve.OnSolved(true);

                monkey.curGO.SetActive(false);
                pig.curGO.SetActive(false);
            }
        }
    }
}
