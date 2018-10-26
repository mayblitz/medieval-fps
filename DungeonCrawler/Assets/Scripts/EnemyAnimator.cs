using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public string idle = "idle";
    public string walk = "walk";
    public string death = "death";
    public string attack = "punch";

    Animation animation;

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    public void Idle()
    {
        if (!animation.IsPlaying(idle))
            animation.CrossFade(idle);
    }

    public void Walk()
    {
        if (!animation.IsPlaying(walk))
            animation.CrossFade(walk);
    }

    public void Die()
    {
        animation.CrossFade(death);
    }

    public void Attack()
    {
        animation.CrossFade(attack);
    }
}
