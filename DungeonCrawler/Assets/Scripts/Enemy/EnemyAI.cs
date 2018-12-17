using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAI : MonoBehaviour
{
    public float maxTargetRange = 10f;
    public float minTargetRange = 2.0f;
    public float attackRange = 2.5f;
    public int damage = 10;

    GameObject player;
    NavMeshAgent navMesh;
    EnemyAnimator animator;
    Vector3 wanderDestination;
    int layerMask;

    void OnDisable()
    {
        navMesh.enabled = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<EnemyAnimator>();
        wanderDestination = transform.position;
        layerMask = 1 << LayerMask.NameToLayer("Building");
    }

    void Update()
    {
        if (IsInRange(attackRange, player.transform.position))
        {
            LookAt();
            animator.AttackAnimation();
            animator.IdleAnimation();
            if (IsInRange(minTargetRange, player.transform.position))
                navMesh.isStopped = true;
        }
        //else if (IsOutOfRange(maxTargetRange, player.transform.position))
        //{
        //    if (IsInRange(3f, wanderDestination))
        //    {
        //        Idle();
        //        SetWanderDestination();
        //    }
        //    else
        //        MoveTo(wanderDestination);
        //}
        else 
            MoveTo(player.transform.position);
    }

    public void Attack()
    {
        if (!IsInRange(attackRange, player.transform.position))
            return;

        var hittables = player.GetComponents(typeof(IHittable));
        if (hittables == null)
            return;

        foreach (IHittable hittable in hittables)
            hittable.Hit(damage);
    }

    bool IsInRange(float range, Vector3 target)
    {
        return Vector3.Distance(transform.position, target) < range;
    }

    bool IsOutOfRange(float range, Vector3 target)
    {
        return Vector3.Distance(transform.position, target) > range;
    }

    void LookAt()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50f);
    }

    void SetWanderDestination()
    {
        float x = Random.Range((int)transform.position.x - 30, (int)transform.position.x + 30);
        float z = Random.Range((int)transform.position.z - 30, (int)transform.position.z + 30);
        Vector3 destination = new Vector3(x, 0, z);
        Collider[] colliders = Physics.OverlapSphere(destination, 5, layerMask);   
        foreach (var collider in colliders)
        {
            if (collider.bounds.Contains(destination))
            {
                Debug.DrawLine(destination, new Vector3(destination.x, 20, destination.z), Color.red, 60 * 1000 * 30);
                return;
            }
        }

        Debug.DrawLine(destination, new Vector3(destination.x, 20, destination.z), Color.green, 60 * 1000 * 30);
        wanderDestination = destination;
    }

    void MoveTo(Vector3 destination)
    {
        animator.WalkAnimation();
        navMesh.isStopped = false;
        navMesh.SetDestination(destination);
    }

    void Idle()
    {
        animator.IdleAnimation();
        navMesh.isStopped = true;
    }
}
