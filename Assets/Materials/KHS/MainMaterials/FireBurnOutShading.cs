using System.Collections;
using UnityEngine;

public class FireBurnOutShading : MonoBehaviour
{
    public Material[] burnMaterials;
    public float burnSpeed = 0.01f;
    private float threshold = 0.5f;
    private AudioSource burnSound;

    private void Awake()
    {
        burnMaterials = GetComponent<MeshRenderer>().materials;
        burnSound = GetComponent<AudioSource>();
    }
    private void Start()
    {
        burnSound.Stop();
        InitializeMaterial(0.5f);
    }

    public void InitializeMaterial(float _threshold)
    {
        threshold = _threshold; // 초기 Threshold 값 설정
        foreach (Material mat in burnMaterials)
        {
            mat.SetFloat("_Threshold", _threshold); // Material 초기화
        }
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
        burnSound.Play();
        while (threshold > -0.5f)
        {
            threshold -= burnSpeed;
            foreach (Material mat in burnMaterials)
            {
                mat.SetFloat("_Threshold", threshold);
            }
            yield return null;
        }
        burnSound.Stop();
    }
    private IEnumerator FireBurnInEffectCoroutine()
    {
        burnSound.Play();
        while (threshold < 0.5f)
        {
            threshold += burnSpeed;
            foreach (Material mat in burnMaterials)
            {
                mat.SetFloat("_Threshold", threshold);
            }
            yield return null;
        }
        burnSound.Stop();
    }
}
