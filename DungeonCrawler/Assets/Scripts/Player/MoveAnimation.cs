using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 lastPosition;
    private float tempTime;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        lastPosition = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;

        if (tempTime > 0.05)
        {
            if (!character.isGrounded)
                animator.SetBool("isFalling", true);
            else
            {
                animator.SetBool("isFalling", false);

                if (lastPosition != character.transform.position)
                {
                    animator.SetBool("isMoving", true);
                    lastPosition = character.transform.position;
                }
                else
                    animator.SetBool("isMoving", false);
            }

            tempTime = 0;
        }
    }
}
