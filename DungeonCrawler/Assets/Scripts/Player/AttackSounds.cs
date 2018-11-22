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
        audio.PlayOneShot(forwardSlash);
    }

    public void BackwardAttackSound()
    {
        audio.PlayOneShot(backwardSlash);
    }

    public void LeftAttackSound()
    {
        audio.PlayOneShot(leftSlash);
    }

    public void RightAttackSound()
    {
        audio.PlayOneShot(rightSlash);
    }

    public void PlayImpactSound(string tag)
    {
        switch(tag)
        {
            case "Flesh":
                audio.PlayOneShot(fleshHit);
                break;
            case "Metal":
                audio.PlayOneShot(metalHit);
                break;
            case "Stone":
                audio.PlayOneShot(stoneHit);
                break;
            case "Wood":
                audio.PlayOneShot(woodHit);
                break;
            case "Sand":
                audio.PlayOneShot(sandHit);
                break;
        }
    }
}
