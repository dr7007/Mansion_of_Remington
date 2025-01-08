using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    public void SartDoorAnimation()
    {
        animator.SetBool("Door",true);
    }

}
