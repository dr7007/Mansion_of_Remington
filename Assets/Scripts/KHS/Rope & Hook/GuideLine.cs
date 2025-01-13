using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GuideLine : MonoBehaviour
{
    private float lerptime = 0f;
    private Transform targetTr = null;
    public TextComparer textCom = null;


    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "ChainLinkEnd")
        {
            targetTr = _collider.transform;
            _collider.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(PositionMove());
        }
    }

    private IEnumerator PositionMove()
    {
        float lerptime = 0f; // lerptime 초기화
        float duration = 3f; // 선형보간에 걸리는 시간 (3초)

        yield return new WaitForSeconds(0.5f); // 0.5초 대기

        Vector3 startPosition = targetTr.position; // 시작 위치 저장
        Quaternion startRotation = targetTr.rotation; // 시작 회전 저장

        while (lerptime < duration)
        {
            lerptime += Time.deltaTime; // 매 프레임 시간 만큼 증가
            float t = lerptime / duration; // 진행 비율 (0~1)

            targetTr.position = Vector3.Lerp(startPosition, transform.position, t); // 위치 보간
            targetTr.rotation = Quaternion.Lerp(startRotation, transform.rotation, t); // 회전 보간

            yield return null; // 다음 프레임까지 대기
        }

        Debug.Log("End!!!");
        textCom.ComparePressed();
    }
}
