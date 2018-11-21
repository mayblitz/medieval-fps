using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AttackSounds : MonoBehaviour
{
    public AudioClip forwardSlash;
    public AudioClip backwardSlash;
    public AudioClip leftSlash;
    public AudioClip rightSlash;

    public AudioClip fleshHit;
    public AudioClip metalHit;
    public AudioClip stoneHit;
    public AudioClip woodHit;
    public AudioClip sandHit;

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

    public void PlayImpactSound(string tag)
    {
        switch(tag)
        {
            case "Flesh":
                audio.clip = fleshHit;
                audio.Play(); ;
                break;
            case "Metal":
                audio.clip = metalHit;
                audio.Play();
                break;
            case "Stone":
                audio.clip = stoneHit;
                audio.Play();
                break;
            case "Wood":
                audio.clip = woodHit;
                audio.Play();
                break;
            case "Sand":
                audio.clip = sandHit;
                audio.Play();
                break;
        }
    }
}
