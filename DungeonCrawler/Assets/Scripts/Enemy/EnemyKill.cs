using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyKill : MonoBehaviour, IDirectionKillable
{
    Rigidbody[] rigidbodies;
    Transform player;

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DisableRagdoll();
    }

    public void Kill(int force, Direction direction)
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;

        EnableRagdoll();
 
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
        {
            rb.AddForce(vectorForce * force, ForceMode.Impulse);
            rb.mass = 0.5f;
            rb.gameObject.layer = LayerMask.NameToLayer("Dead");
        }

        this.gameObject.layer = LayerMask.NameToLayer("Dead");
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
