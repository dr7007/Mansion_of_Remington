using UnityEngine;

public class PadLockEmissionColor : MonoBehaviour
{
    public bool isSelect;
    [SerializeField] private float _timeBlinking = 0.5f;

    // material 반짝이게 하는 코드
    public void BlinkingMaterial()
    {
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        
        if (isSelect)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.clear, Color.yellow, Mathf.PingPong(Time.time, _timeBlinking)));
        }
        if (isSelect == false)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }

    }
}
