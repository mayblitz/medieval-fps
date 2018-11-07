﻿using UnityEngine;

[RequireComponent(typeof(Stats))]
public class HitDamage : MonoBehaviour, IHittable
{
    Stats stats;
    IKillable killable;

    bool isDead = false;

    void Start()
    {
        stats = GetComponent<Stats>();
        killable = (IKillable)GetComponent(typeof(IKillable));
        if (killable == null)
            throw new MissingComponentException("Requires implementation of IKillable");
    }

    public void Hit(int damage, Direction direction)
    {
        stats.health -= damage;
        print(stats.health);
        if (stats.health <= 0 && !isDead)
        {
            isDead = true;
            int force = damage / 2;
            killable.Kill(force, direction);
        }
    }
}
