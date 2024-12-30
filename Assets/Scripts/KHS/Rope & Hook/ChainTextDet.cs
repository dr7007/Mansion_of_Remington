using UnityEngine;
using TMPro;

public class ChainTextDet : MonoBehaviour
{
    public TextMeshPro textMeshPro; // 대상 TextMeshPro
    public string chainTag = "Chain"; // 쇠사슬 태그
    [SerializeField]
    private GameObject[] characterColliders; // 글자별 Collider 오브젝트
    public Vector3 colVec = Vector3.zero;

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

            charCollider.transform.position = (bottomLeft + topRight) / 2;
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


public class CollisionHandlerWithAngle : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private int characterIndex;

    public float minAngle = 80f; // 허용 각도 범위 (최소)
    public float maxAngle = 100f; // 허용 각도 범위 (최대)

    public void Initialize(TextMeshPro textMeshPro, int characterIndex)
    {
        this.textMeshPro = textMeshPro;
        this.characterIndex = characterIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 쇠사슬인지 확인
        if (other.CompareTag("Chain"))
        {
            // 각도를 계산하고 조건을 만족하는 경우에만 색상 변경
            if (IsValidAngle(other.transform))
            {
                ChangeCharacterColor(Color.red);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 충돌 종료 시 색상을 원래대로 복원
        if (other.CompareTag("Chain"))
        {
            ChangeCharacterColor(Color.white);
        }
    }

    bool IsValidAngle(Transform chainTransform)
    {
        // 글자 표면의 방향 (텍스트의 정면 방향)
        Vector3 textNormal = transform.up; // 텍스트의 로컬 Up 방향
        Vector3 chainDirection = chainTransform.forward; // 쇠사슬의 진행 방향

        // 각도 계산
        float angle = Vector3.Angle(textNormal, chainDirection);

        // 허용 각도 범위 확인
        return angle >= minAngle && angle <= maxAngle;
    }

    void ChangeCharacterColor(Color color)
    {
        // 글자 색상 변경
        TMP_TextInfo textInfo = textMeshPro.textInfo;
        int meshIndex = textInfo.characterInfo[characterIndex].materialReferenceIndex;
        int vertexIndex = textInfo.characterInfo[characterIndex].vertexIndex;

        Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;
        for (int i = 0; i < 4; i++)
        {
            vertexColors[vertexIndex + i] = color;
        }

        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}
