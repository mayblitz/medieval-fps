using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Stats))]
public class HitDamage : MonoBehaviour, IHittable
{
    Stats stats;
    EnemyAI enemyAI;
    Animation animation;

    void Start()
    {
        stats = GetComponent<Stats>();
        enemyAI = GetComponent<EnemyAI>();
        animation = GetComponent<Animation>();
    }

    public void Hit(int damage)
    {
        stats.health -= damage;

        if (stats.health <= 0)
        {
            animation.Play("death");
            enemyAI.enabled = false;
            StartCoroutine(Destroy());
        }
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
