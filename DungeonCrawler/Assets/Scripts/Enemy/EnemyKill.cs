using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyKill : MonoBehaviour, IKillable
{
    EnemyAI enemyAI;
    EnemyAnimator animator;
    Rigidbody[] rigidbodies;

    void Start()
    {

        enemyAI = GetComponent<EnemyAI>();
        animator = GetComponent<EnemyAnimator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    public void Kill(int force, Direction direction)
    {
        GetComponent<Animator>().enabled = false;
        enemyAI.enabled = false;

        EnableRagdoll();
        var player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 vectorForce;

        if (direction == Direction.Backward)
            vectorForce = player.forward;
        else if (direction == Direction.Left)
            vectorForce = player.right;
        else if (direction == Direction.Right)
            vectorForce = -player.right;
        else
            vectorForce = -transform.up;

        foreach (Rigidbody rb in rigidbodies)
            rb.AddForce(vectorForce * force, ForceMode.Impulse);

        Destroy(gameObject, 60);
    }

    void EnableRagdoll()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }
    }

    void DisableRagdoll()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
    }
}
