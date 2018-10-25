using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;

    public int damage = 10;

    public void Attack()
    {
        var hits = Physics.OverlapSphere(attackPoint.position, 0.5f);

        foreach (var hit in hits)
        {
            var hittables = hit.GetComponents(typeof(IHittable));

            if (hittables == null)
                return;

            foreach (IHittable hittable in hittables)
                hittable.Hit(damage);
        }
    }
}
