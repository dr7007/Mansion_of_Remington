using System.Collections.Generic;
using UnityEngine;

public class BigChessBoard : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    public float tileSize = 1f;   
    public int boardSize = 8;
    public float spacing = 0.5f;
    public float startPos = -5.25f;
    public int[] paths = { 1, 2, 3, 4, 3, 2, 10, 18, 26, 27, 28, 36, 44, 52, 60, 61, 62, 63, 64};
    public int currentIdx = 1;
    public bool clear = false;
    private List<GameObject> tiles = new List<GameObject>();

    private void Awake()
    {

    }

    private void Start()
    {
        tiles.Clear();
        Reset();
        CreateTiles();
    }

    private void Update()
    {
        if (currentIdx == 20)
        {
            clear = true;
            Debug.Log("clear");
            currentIdx = -1;
            DestroyTiles();
        }
    }

    private void CreateTiles()
    {
        // 8x8 체스판 생성
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                // 각 타일의 위치 계산
                Vector3 position = new Vector3(startPos + col * (tileSize + spacing), 0.6f , startPos + row * (tileSize + spacing));

                // 타일을 생성하고 위치를 지정
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tile.name = "" + (row * boardSize + col + 1);  // 번호를 이름으로 지정

                tile.transform.localScale = new Vector3(1f, 1f, 1f); 

                // 타일 리스트에 추가
                tiles.Add(tile);

                // 번호를 타일의 상단에 표시할 경우 (옵션)
                // 번호 텍스트를 만들고, 타일에 추가할 수 있습니다.
                // 텍스트는 필요 없다면 생략 가능합니다.
                if (tile.GetComponentInChildren<TextMesh>() != null)
                {
                    TextMesh textMesh = tile.GetComponentInChildren<TextMesh>();
                    textMesh.text = (row * boardSize + col + 1).ToString();
                }
            }
        }
    }

    public void Reset()
    {
        currentIdx = 1;
    }

    private void DestroyTiles()
    {
        foreach (GameObject tile in tiles)
        {
            if (tile != null)
            {
                Destroy(tile);
            }
        }
        tiles.Clear();
    }

}
