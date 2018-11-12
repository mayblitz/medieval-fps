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

    void OnDisable()
    {
        navMesh.enabled = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<EnemyAnimator>();
    }

    void Update()
    {
        if (IsInRange(attackRange))
        {
            LookAt();
            animator.AttackAnimation();
            animator.IdleAnimation();
            if (IsInRange(minTargetRange))
                navMesh.isStopped = true;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > maxTargetRange)
        {
            animator.IdleAnimation();
            navMesh.isStopped = true;
        }
        else 
        {
            animator.WalkAnimation();
            navMesh.isStopped = false;
            navMesh.SetDestination(player.transform.position);
        }
    }

    public void Attack()
    {
        if (!IsInRange(attackRange))
            return;

        var hittables = player.GetComponents(typeof(IHittable));

        if (hittables == null)
            return;

        foreach (IHittable hittable in hittables)
            hittable.Hit(damage);
    }

    bool IsInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) < range;
    }

    void LookAt()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50f);
    }
}
