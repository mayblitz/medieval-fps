using UnityEngine;

[RequireComponent(typeof(Stats))]
public class PlayerHitDamage : MonoBehaviour, IHittable
{
    private Stats stats;
    private IKillable killable;

    void Start()
    {
        stats = GetComponent<Stats>();
        killable = (IKillable)GetComponent(typeof(IKillable));
        if (killable == null)
            throw new MissingComponentException("Requires implementation of IKillable");
    }

    public void Hit(int damage)
    {
        stats.health -= damage;
        print(stats.health);

        if (stats.health <= 0 && !killable.IsDead)
            killable.Kill();
    }
}