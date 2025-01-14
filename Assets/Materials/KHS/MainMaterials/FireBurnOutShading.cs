using System.Collections;
using UnityEngine;

public class FireBurnOutShading : MonoBehaviour
{
    public Material burnMaterial;
    public float burnSpeed = 0.01f;
    private float threshold = 0.5f;

    private void Start()
    {
        InitializeMaterial();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(FireBurnEffectCoroutine());
        }
    }
    public void InitializeMaterial()
    {
        threshold = 0.5f; // 초기 Threshold 값 설정
        burnMaterial.SetFloat("_Threshold", threshold); // Material 초기화
    }

    private IEnumerator FireBurnEffectCoroutine()
    {
        while (threshold > -0.5f)
        {
            threshold -= burnSpeed;
            burnMaterial.SetFloat("_Threshold", threshold);
            yield return null;
        }
        if(threshold <= -0.5f)
        {
            gameObject.SetActive(false);
        }
    }
}
