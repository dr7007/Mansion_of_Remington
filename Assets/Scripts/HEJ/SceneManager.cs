using System.Collections;
using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PressAnyKey;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            PressAnyKey.enabled = false;
        }
    }
    private void Start()
    {

    }

}
