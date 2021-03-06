﻿using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform attackPointTip;

    [SerializeField]
    private Transform attackPointBase;

    [SerializeField]
    private float size = 0.5f;

    [SerializeField]
    private int playerDamage = 10;

    private AttackSounds attackSounds;
    private int layerMask;

    private void Start()
    {
        attackSounds = GetComponent<AttackSounds>();

        int building = LayerMask.NameToLayer("Building");
        int enemy = LayerMask.NameToLayer("Enemy");
        layerMask = (1 << building) | (1 << enemy);
    }

    public void ForwardAttack()
    {
        Attack(playerDamage, Direction.Forward);
    }

    public void BackwardAttack()
    {
        Attack(playerDamage, Direction.Backward);
    }

    public void LeftAttack()
    {
        Attack(playerDamage, Direction.Left);
    }

    public void RightAttack()
    {
        Attack(playerDamage, Direction.Right);
    }

    private void Attack(int damage, Direction direction)
    {
        var hits = Physics.OverlapCapsule(attackPointTip.position, attackPointBase.position, size, layerMask);

        foreach (var hit in hits)
        {
            attackSounds.PlayImpactSound(hit.tag);

            var directionHittables = hit.GetComponents(typeof(IDirectionHittable));

            if (directionHittables != null)
            {
                foreach (IDirectionHittable hittable in directionHittables)
                    hittable.Hit(damage, direction);
            }   
        }
    }
}
