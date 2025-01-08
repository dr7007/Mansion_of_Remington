using System.Globalization;
using TMPro;
using UnityEngine;

public class CollisionHandlerWithAngle : MonoBehaviour
{
    private ChainTextDet sentenceTmp;
    private TextMeshPro textMeshPro;
    private int characterIndex;

    public float minAngle = 80f; // 허용 각도 범위 (최소)
    public float maxAngle = 100f; // 허용 각도 범위 (최대)


    public void Initialize(TextMeshPro _textMeshPro, int _characterIndex)
    {
        sentenceTmp = _textMeshPro.gameObject.GetComponent<ChainTextDet>();
        textMeshPro = _textMeshPro;
        characterIndex = _characterIndex;
    }

    void OnTriggerStay(Collider _collider)
    {
        // 충돌한 오브젝트가 쇠사슬인지 확인
        if (_collider.CompareTag("Chain"))
        {
            // 각도를 계산하고 조건을 만족하는 경우에만 색상 변경
            if (IsValidAngle(_collider.transform))
            {
                sentenceTmp.onLight = textMeshPro.textInfo.characterInfo[characterIndex].character;
                Debug.Log("Char : " + sentenceTmp.onLight);
                ChangeCharacterColor(Color.red);
            }
        }
    }

    void OnTriggerExit(Collider _collider)
    {
        // 충돌 종료 시 색상을 원래대로 복원
        if (_collider.CompareTag("Chain"))
        {
            ChangeCharacterColor(Color.white);
        }
    }

    bool IsValidAngle(Transform _chainTransform)
    {
        // 글자 표면의 방향 (텍스트의 정면 방향)
        Vector3 textNormal = transform.up; // 텍스트의 로컬 Up 방향
        Vector3 chainDirection = _chainTransform.forward; // 쇠사슬의 진행 방향

        // 각도 계산
        float angle = Vector3.Angle(textNormal, chainDirection);

        // 허용 각도 범위 확인
        return angle >= minAngle && angle <= maxAngle;
    }

    void ChangeCharacterColor(Color _color)
    {
        // 글자 색상 변경
        TMP_TextInfo textInfo = textMeshPro.textInfo;
        int meshIndex = textInfo.characterInfo[characterIndex].materialReferenceIndex;
        int vertexIndex = textInfo.characterInfo[characterIndex].vertexIndex;
        

        Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;
        for (int i = 0; i < 4; i++)
        {
            vertexColors[vertexIndex + i] = _color;
        }

        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}

