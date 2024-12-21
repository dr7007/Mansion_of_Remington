using UnityEngine;

public class BigTile : MonoBehaviour
{
    private BigChessBoard board;
    private void Start()
    {
        GameObject boardGo = GameObject.Find("P_BigBoard");
        board = boardGo.GetComponent<BigChessBoard>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��ȣ�� �̸��� ��ġ�Ҷ�
        if (board.paths[board.currentIdx-1].ToString() == gameObject.name)
        {
            // ���� �ٲ�(�ʷ�)
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color = Color.green;
            color.a = 1f;
            board.currentIdx++;
            gameObject.GetComponent<Renderer>().material.color = color;

            // �°� ���� �˸��� �ڵ� (������ ���ڷ�)
            ChangeSmallBoardCorrect(gameObject.name);
        }
        else
        {
            // ���� �ٲ�(����)
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color = Color.red;
            color.a = 1f;
            gameObject.GetComponent<Renderer>().material.color = color;

            // �ʱ�ȭ �ϴ� �ڵ�
            board.Reset();

            // Ʋ���� ���� �˸��� �ڵ� (�����϶�� �ϸ� �ɵ�)
            ChangeSmallBoardWrong(gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���� �ٲ�(�Ⱥ��̰�)
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0f;
        gameObject.GetComponent<Renderer>().material.color = color;

        // ���Դٴ°� �˸��� �ڵ� (������ ���ڷ�)
        ChangeSmallBoardExit(gameObject.name);
    }

    private void ChangeSmallBoardCorrect(string _name)
    {
        // Ư�� ��ũ��Ʈ�� ���� ��� ��ü�� ã��
        SmallTile[] targets = FindObjectsByType<SmallTile>(FindObjectsSortMode.None);

        // ã�� ��� ��ü�� �޽����� broadcast
        foreach (SmallTile target in targets)
        {
            target.Correct(_name);
        }
    }

    private void ChangeSmallBoardWrong(string _name)
    {
        // Ư�� ��ũ��Ʈ�� ���� ��� ��ü�� ã��
        SmallTile[] targets = FindObjectsByType<SmallTile>(FindObjectsSortMode.None);

        // ã�� ��� ��ü�� �޽����� broadcast
        foreach (SmallTile target in targets)
        {
            target.Wrong(_name);
        }
    }

    private void ChangeSmallBoardExit(string _name)
    {
        // Ư�� ��ũ��Ʈ�� ���� ��� ��ü�� ã��
        SmallTile[] targets = FindObjectsByType<SmallTile>(FindObjectsSortMode.None);

        // ã�� ��� ��ü�� �޽����� broadcast
        foreach (SmallTile target in targets)
        {
            target.Exit(_name);
        }
    }
}
