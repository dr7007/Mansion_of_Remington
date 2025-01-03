using UnityEngine;

public class Cubeparticle : MonoBehaviour
{
    public ParticleSystem particle;
    private Animator animator;

    private void Start()
    {
        particle.Stop();
        animator = this.GetComponent<Animator>();
    }

    private void congration()
    {
        particle.Play();

    }

    public void StartAnimation()
    {

        animator.SetBool("Start", true);
    }
}
