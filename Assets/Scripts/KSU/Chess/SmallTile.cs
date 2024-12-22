using UnityEngine;

public class SmallTile : MonoBehaviour
{

    private SmallChessBoard board;
    private void Start()
    {
        GameObject boardGo = GameObject.Find("P_SmallBoard");
        board = boardGo.GetComponent<SmallChessBoard>();
    }

    public void Correct(string _name)
    {
        if (gameObject.name == _name)
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color = Color.green;
            color.a = 1f;
            board.currentIdx++;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }

    public void Wrong(string _name)
    {
        if (gameObject.name == _name)
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color = Color.red;
            color.a = 1f;
            gameObject.GetComponent<Renderer>().material.color = color;

            board.Reset();
        }
    }

    public void Exit(string _name)
    {
        if (gameObject.name == _name)
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }


}