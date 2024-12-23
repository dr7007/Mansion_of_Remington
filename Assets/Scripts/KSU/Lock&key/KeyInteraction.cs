using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public bool IsInteraction = false;
    public bool canInteraction = false;
    public string InteractionName = "";
    public float DetectRange = 0f;
    public float lerpTime = 0f;
    public LayerMask interactionLayer = 0;
    public List<GameObject> detectedObjects = new List<GameObject>();
    public GCondition solve;

    private void Update()
    {
        DetectInteraction();

        if (canInteraction && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Interaction());
        }
    }

    // 범위내에 해당이름을 가지고, 해당 레이어에 있는 상호작용 할것을 찾음
    private void DetectInteraction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, DetectRange, interactionLayer);

        List<GameObject> currentDetectedObjects = new List<GameObject>();

        foreach (Collider collider in hitColliders)
        {
            // 이름이 InteractionName과 일치하는지 확인
            if (collider.gameObject.name == InteractionName)
            {
                currentDetectedObjects.Add(collider.gameObject);

                // Outline 컴포넌트가 있는지 확인
                Outline outline = collider.GetComponent<Outline>();
                if (outline != null)
                {
                    // Outline 스크립트 활성화
                    outline.enabled = true;
                    canInteraction = true;
                }
            }
        }

        foreach (GameObject detectedObject in detectedObjects)
        {
            if (!currentDetectedObjects.Contains(detectedObject))  // 현재 범위 내 객체에 포함되지 않으면
            {
                // 범위 밖으로 나갔으므로 Outline 비활성화
                Outline outline = detectedObject.GetComponent<Outline>();
                if (outline != null)
                {
                    outline.enabled = false;
                    canInteraction = false;
                }
            }
        }

        // 객체 리스트 최신화
        detectedObjects = currentDetectedObjects;
    }

    // 키가 해당 자물쇠에 꽂혀서 돌아가도록 동작?
    private IEnumerator Interaction()
    {
        // 열쇠를 자물쇠 위치에 자물쇠 각도로
        transform.position = detectedObjects[0].transform.position;
        transform.rotation = detectedObjects[0].transform.rotation;

        // 열쇠를 구멍에 맞게 수정
        Quaternion currentRotation = transform.rotation;
        currentRotation *= Quaternion.Euler(180f, 90f, 0f);
        transform.rotation = currentRotation;

        yield return new WaitForSeconds(1f);

        // Lerp하게 열쇠가 돌아가도록 설정해야하나?
        float timeElapsed = 0f;
        Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 90f, 0f);

        while (timeElapsed < lerpTime)
        {
            timeElapsed += Time.deltaTime;
            float lerpValue = timeElapsed / lerpTime;

            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, lerpValue);

            yield return null;
        }

        // 이제 lock의 interaction호출 (자물쇠 열리도록)
        solve.OnSolved(true);
    }
}
