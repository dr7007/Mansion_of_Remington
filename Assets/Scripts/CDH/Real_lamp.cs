using UnityEngine;

public class Real_lamp : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("플레이어다");
            AudioManager.instance.PlaySfx(AudioManager.sfx.Noise);
            animator.SetBool("isEnter", true);
        }
    }
}
