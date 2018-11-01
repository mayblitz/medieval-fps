using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetLayerWeight(1, 1f);
            animator.SetTrigger("isAttacking");
        }
    }
}
