using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isCharging;

    void Start()
    {
        animator = GetComponent<Animator>();
        isCharging = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isCharging)
            {
                animator.ResetTrigger("Attack");
                isCharging = true;
                animator.SetLayerWeight(1, 1f);

                if (Input.GetKey(KeyCode.S))
                    animator.SetTrigger("ChargeBackAttack");
                else if (Input.GetKey(KeyCode.A))
                    animator.SetTrigger("ChargeLeftAttack");
                else if (Input.GetKey(KeyCode.D))
                    animator.SetTrigger("ChargeRightAttack");
                else
                    animator.SetTrigger("ChargeForwardAttack");
            }
        }
        else if (isCharging)
        {
            animator.ResetTrigger("ChargeForwardAttack");
            animator.ResetTrigger("ChargeBackAttack");
            animator.ResetTrigger("ChargeLeftAttack");
            animator.ResetTrigger("ChargeRightAttack");
            animator.SetTrigger("Attack");
            isCharging = false;
        }
    }
}
