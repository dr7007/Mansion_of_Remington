using System.Collections;
using UnityEngine;

public class FireBurnOutShading : MonoBehaviour
{
    public Material burnMaterial;
    public float burnSpeed = 0.01f;
    private float threshold = 0.5f;

    private void Awake()
    {
        burnMaterial = GetComponent<MeshRenderer>().material;
    }
    private void Start()
    {
        InitializeMaterial(0.5f);
    }

    public void InitializeMaterial(float _threshold)
    {
        threshold = _threshold; // 초기 Threshold 값 설정
        burnMaterial.SetFloat("_Threshold", _threshold); // Material 초기화
    }

    public void FireFadeOut()
    {
        InitializeMaterial(0.5f);
        StartCoroutine(FireBurnOutEffectCoroutine());
    }
    public void FireFadeIn()
    {
        InitializeMaterial(-0.5f);
        StartCoroutine(FireBurnInEffectCoroutine());
    }

    private IEnumerator FireBurnOutEffectCoroutine()
    {
        while (threshold > -0.5f)
        {
            threshold -= burnSpeed;
            burnMaterial.SetFloat("_Threshold", threshold);
            yield return null;
        }
    }
    private IEnumerator FireBurnInEffectCoroutine()
    {
        while (threshold < 0.5f)
        {
            threshold += burnSpeed;
            burnMaterial.SetFloat("_Threshold", threshold);
            yield return null;
        }
    }
}
