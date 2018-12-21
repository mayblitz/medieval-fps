using UnityEngine;

[RequireComponent(typeof(Stats))]
public class EnemyHitDamage : MonoBehaviour, IDirectionHittable
{
    private Stats stats;
    private IDirectionKillable killable;

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

        if (stats.health <= 0 && !killable.IsDead)
        {
            int force = damage / 2;
            killable.Kill(force, direction);
        }
    }
}
