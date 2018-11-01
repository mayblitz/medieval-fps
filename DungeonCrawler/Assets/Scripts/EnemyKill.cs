using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyKill : MonoBehaviour, IKillable
{
    EnemyAI enemyAI;
    EnemyAnimator animator;
    CapsuleCollider collider;

    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        animator = GetComponent<EnemyAnimator>();
        collider = GetComponent<CapsuleCollider>();
    }

    public void Kill()
    {
        animator.DieAnimation();
        enemyAI.enabled = false;
        collider.enabled = false;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);

        float currentY = gameObject.transform.position.y;
        float targetY = gameObject.transform.position.y - 2;

        while (currentY > targetY)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
            currentY = gameObject.transform.position.y;
            yield return null;
        }

        Destroy(gameObject);
    }
}
