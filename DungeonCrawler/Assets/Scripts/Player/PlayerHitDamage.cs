using UnityEngine;

[RequireComponent(typeof(Stats))]
public class PlayerHitDamage : MonoBehaviour, IHittable
{
    private Stats stats;
    private IKillable killable;
    private bool isDead;

    void Start()
    {
        stats = GetComponent<Stats>();
        isDead = false;
        killable = (IKillable)GetComponent(typeof(IKillable));
        if (killable == null)
            throw new MissingComponentException("Requires implementation of IKillable");
    }

    public void Hit(int damage)
    {
        stats.health -= damage;
        print(stats.health);

        if (stats.health <= 0 && !isDead)
        {
            isDead = true;
            killable.Kill();
        }
    }
}