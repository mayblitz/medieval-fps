using UnityEngine;

public class AttackSounds : MonoBehaviour
{
    public AudioClip forwardSlash;
    public AudioClip backwardSlash;
    public AudioClip leftSlash;
    public AudioClip rightSlash;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ForwardAttackSound()
    {
        audio.clip = forwardSlash;
        audio.Play();
    }

    public void BackwardAttackSound()
    {
        audio.clip = backwardSlash;
        audio.Play();
    }

    public void LeftAttackSound()
    {
        audio.clip = leftSlash;
        audio.Play();
    }

    public void RightAttackSound()
    {
        audio.clip = rightSlash;
        audio.Play();
    }
}
