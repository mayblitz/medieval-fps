using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void IdleAnimation()
    {
        animator.SetBool("isWalking", false);
    }

    public void WalkAnimation()
    {
        animator.SetBool("isWalking", true);
    }

    public void DieAnimation()
    {
        animator.SetLayerWeight(2, 1f);
        animator.SetTrigger("isDead");
    }

    public void AttackAnimation()
    {
        animator.SetLayerWeight(1, 1f);
        animator.SetTrigger("isAttacking");
    }
}
