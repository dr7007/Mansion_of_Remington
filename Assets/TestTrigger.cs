using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggerµé¾î¿È");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger³ª°¨");
    }
}
