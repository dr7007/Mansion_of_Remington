using UnityEngine;

public class Cube4ChessButton : MonoBehaviour
{
    public int TheChessButton = 0;

    public bool TheCube4Result = false;

    private void Update()
    {
        TheChessButtonOnClick();
    }

    private void TheChessButtonOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.tag == "ChessButton")
                {
                    TheChessButton = 1;
                }
            }
        }
    }


    //체스판에 상호작용

}
