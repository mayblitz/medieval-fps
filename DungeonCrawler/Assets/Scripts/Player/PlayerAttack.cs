using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float size = 0.5f;
    public int playerDamage = 10;

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
        var hits = Physics.OverlapSphere(attackPoint.position, size);

        foreach (var hit in hits)
        {
            var hittables = hit.GetComponents(typeof(IHittable));

            if (hittables == null)
                return;

            foreach (IHittable hittable in hittables)
                hittable.Hit(damage, direction);
        }
    }
}
