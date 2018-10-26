using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyKill : MonoBehaviour, IKillable
{
    EnemyAI enemyAI;
    EnemyAnimator animator;

    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        animator = GetComponent<EnemyAnimator>();
    }

    public void Kill()
    {
        animator.Die();
        enemyAI.enabled = false;
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
