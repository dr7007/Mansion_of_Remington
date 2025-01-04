using UnityEngine;
using Photon.Pun;

public class SmallTile : MonoBehaviourPun
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

            photonView.RPC("CorrectRPC", RpcTarget.Others, _name);
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

            photonView.RPC("WrongRPC", RpcTarget.Others, _name);
        }
    }

    public void Exit(string _name)
    {
        if (gameObject.name == _name)
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 0f;
            gameObject.GetComponent<Renderer>().material.color = color;

            photonView.RPC("ExitRPC", RpcTarget.Others, _name);
        }
    }

    [PunRPC]
    private void CorrectRPC(string _name)
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

    [PunRPC]
    private void WrongRPC(string _name)
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

    [PunRPC]
    private void ExitRPC(string _name)
    {
        if (gameObject.name == _name)
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }

}