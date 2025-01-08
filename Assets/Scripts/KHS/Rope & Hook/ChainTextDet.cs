using UnityEngine;
using TMPro;

public class ChainTextDet : MonoBehaviour
{
    public TextMeshPro textMeshPro; // 대상 TextMeshPro
    public string chainTag = "Chain"; // 쇠사슬 태그
    [SerializeField]
    private GameObject[] characterColliders; // 글자별 Collider 오브젝트
    public Vector3 colVec = Vector3.zero;
    public char onLight = ' ';

    void Start()
    {
        GenerateCharacterColliders();
    }

    void GenerateCharacterColliders()
    {
        // 텍스트 정보를 초기화
        TMP_TextInfo textInfo = textMeshPro.textInfo;
        textMeshPro.ForceMeshUpdate();

        // 글자 개수만큼 Collider 오브젝트 생성
        characterColliders = new GameObject[textInfo.characterCount];

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

            // 보이지 않는 글자는 스킵
            if (!charInfo.isVisible) continue;

            // 글자별 Collider 오브젝트 생성
            GameObject charCollider = new GameObject($"CharCollider_{i}");
            charCollider.transform.parent = textMeshPro.transform;

            // 글자 위치와 크기 설정
            Vector3 bottomLeft = textMeshPro.transform.TransformPoint(charInfo.bottomLeft);
            Vector3 topRight = textMeshPro.transform.TransformPoint(charInfo.topRight);

            // 텍스트의 로컬 회전을 반영한 중심 위치 및 크기
            charCollider.transform.position = (bottomLeft + topRight) / 2;
            charCollider.transform.rotation = textMeshPro.transform.rotation; // 텍스트의 회전값 적용
            charCollider.transform.localScale = colVec;

            // BoxCollider 추가 및 초기화
            BoxCollider boxCollider = charCollider.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true; // Trigger로 설정

            // CollisionHandler 스크립트를 추가
            CollisionHandlerWithAngle collisionHandler = charCollider.AddComponent<CollisionHandlerWithAngle>();
            collisionHandler.Initialize(textMeshPro, i);
            

            characterColliders[i] = charCollider;
        }
    }

}
