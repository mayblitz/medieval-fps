using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAI : MonoBehaviour
{
    public float outOfReachRange = 10f;
    public float attackRange = 2.5f;
    public float attackDelay = 1f;
    public int damage = 10;

    GameObject player;
    NavMeshAgent navMesh;
    EnemyAnimator animator;

    bool isAttacking = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<EnemyAnimator>();
    }

    void Update()
    {
        if (!isAttacking)
        {
            if (IsInAttackRange())
            {
                isAttacking = true;
                navMesh.isStopped = true;
                animator.Attack();
                Invoke("Attack", attackDelay);
            }
            else if (Vector3.Distance(transform.position, player.transform.position) > outOfReachRange)
            {
                animator.Idle();
                navMesh.isStopped = true;
            }
            else
            {
                animator.Walk();
                navMesh.isStopped = false;
                navMesh.SetDestination(player.transform.position);
            }
        }
    }

    void OnDisable()   
    {
        navMesh.enabled = false;
    }

    void Attack()
    {
        isAttacking = false;
        
        if (!IsInAttackRange())
            return;

        var hittables = player.GetComponents(typeof(IHittable));

        if (hittables == null)
            return;

        foreach (IHittable hittable in hittables)
            hittable.Hit(damage);
    }

    bool IsInAttackRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) < attackRange;
    }
}
