using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    Animator animator;
    bool isCharging = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isCharging)
            {
                isCharging = true;
                animator.SetLayerWeight(1, 1f);

                if (Input.GetKey(KeyCode.W))
                    animator.SetTrigger("ChargeForwardAttack");
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
            animator.SetTrigger("Attack");
            isCharging = false;
        }
    }
}
