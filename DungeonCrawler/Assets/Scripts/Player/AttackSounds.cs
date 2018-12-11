using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AttackSounds : MonoBehaviour
{
    public AudioClip forwardSlash;
    public AudioClip backwardSlash;
    public AudioClip leftSlash;
    public AudioClip rightSlash;

    public AudioClip[] fleshHits;
    public AudioClip[] metalHits;
    public AudioClip[] stoneHits;
    public AudioClip[] woodHits;
    public AudioClip[] sandHits;

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
        int i;

        switch(tag)
        {
            case "Flesh":
                i = Random.Range(0, fleshHits.Length);
                audio.PlayOneShot(fleshHits[i]);
                break;
            case "Metal":
                i = Random.Range(0, metalHits.Length);
                audio.PlayOneShot(metalHits[i]);
                break;
            case "Stone":
                i = Random.Range(0, stoneHits.Length);
                audio.PlayOneShot(stoneHits[i]);
                break;
            case "Wood":
                i = Random.Range(0, woodHits.Length);
                audio.PlayOneShot(woodHits[i]);
                break;
            case "Sand":
                i = Random.Range(0, sandHits.Length);
                audio.PlayOneShot(sandHits[i]);
                break;
        }
    }
}
