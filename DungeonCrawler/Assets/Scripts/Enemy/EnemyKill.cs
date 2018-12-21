using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyKill : MonoBehaviour, IDirectionKillable
{
    private Rigidbody[] rigidbodies;
    private Transform player;

    public bool IsDead { get; private set; }

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DisableRagdoll();
        IsDead = false;
    }

    public void Kill(int force, Direction direction)
    {
        IsDead = true;
        DisableComponents();
        EnableRagdoll();
        Vector3 vectorForce = GetDirectionForce(direction);

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddForce(vectorForce * force, ForceMode.Impulse);
            rb.mass = 0.5f;
            rb.gameObject.layer = LayerMask.NameToLayer("Dead");
        }

        this.gameObject.layer = LayerMask.NameToLayer("Dead");
        Destroy(gameObject, 60);
    }

    void DisableComponents()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
    }

    Vector3 GetDirectionForce(Direction direction)
    {
        if (direction == Direction.Backward)
            return player.forward;
        else if (direction == Direction.Left)
            return player.right;
        else if (direction == Direction.Right)
            return -player.right;
        else
            return -transform.up;
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
