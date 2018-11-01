using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    //public string idle = "idle";
    //public string walk = "walk";
    //public string death = "death";
    //public string attack = "punch";

    //Animation animation;
    Animator animator;

    private void Start()
    {
        //animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }

    public void IdleAnimation()
    {
        //if (!animation.IsPlaying(idle))
        //    animation.CrossFade(idle);

        //if (isWalking)
        //{
        //    isWalking = !isWalking;
            animator.SetBool("isWalking", false);
        //}
    }

    public void WalkAnimation()
    {
        //if (!animation.IsPlaying(walk))
        //    animation.CrossFade(walk);
        //if (!isWalking)
        //{
        //    isWalking = !isWalking;
            animator.SetBool("isWalking", true);
        //}
    }

    public void DieAnimation()
    {
        //animation.CrossFade(death);
        animator.SetLayerWeight(2, 1f);
        animator.SetTrigger("isDead");
    }

    public void AttackAnimation()
    {
        //animation.CrossFade(attack);
        animator.SetLayerWeight(1, 1f);
        animator.SetTrigger("isAttacking");
    }
}
