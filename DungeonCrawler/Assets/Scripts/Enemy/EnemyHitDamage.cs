using UnityEngine;

[RequireComponent(typeof(Stats))]
public class EnemyHitDamage : MonoBehaviour, IDirectionHittable
{
    Stats stats;
    IDirectionKillable killable;

    bool isDead = false;

    void Start()
    {
        stats = GetComponent<Stats>();
        killable = (IDirectionKillable)GetComponent(typeof(IDirectionKillable));
        if (killable == null)
            throw new MissingComponentException("Requires implementation of IDirectionKillable");
    }

    public void Hit(int damage, Direction direction)
    {
        stats.health -= damage;

        if (stats.health <= 0 && !isDead)
        {
            isDead = true;
            int force = damage / 2;
            killable.Kill(force, direction);
        }
    }
}
