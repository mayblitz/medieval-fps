using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedAnimation : MonoBehaviour {

    public CharacterController character;

    Animator animator;
    Vector3 lastPosition;
    float tempTime;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        lastPosition = character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        tempTime += Time.deltaTime;

        if (tempTime > 0.02)
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
                {
                    animator.SetBool("isMoving", false);
                }
            }
            tempTime = 0;
        }
	}
}
