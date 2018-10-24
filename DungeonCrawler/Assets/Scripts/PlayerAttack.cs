using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;

    public void Attack()
    {
        var hits = Physics.OverlapSphere(attackPoint.position, 0.5f);

        foreach (var hit in hits)
        {
            print(hit.name);
        }
    }
}
