using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sandSteps;

    [SerializeField]
    private AudioClip[] stoneSteps;

    private AudioSource audio;
    private CharacterController character;
    private LayerMask layerMask;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        character = GetComponent<CharacterController>();
        int building = LayerMask.NameToLayer("Building");
        int ground = LayerMask.NameToLayer("Ground");
        layerMask = (1 << building) | (1 << ground);

        InvokeRepeating("PlayFootsteps", 0.1f, 0.5f);
    }

    private void PlayFootsteps()
    {
        RaycastHit hit;

        if (
            character.velocity.magnitude > 0 &&
            character.isGrounded &&
            Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity, layerMask))
        {       
            AudioClip clip;

            if (hit.collider.tag == "Stone")
            {
                int i = Random.Range(0, stoneSteps.Length);
                clip = stoneSteps[i];
            }
            else
            {
                int i = Random.Range(0, sandSteps.Length);
                clip = sandSteps[i];
            }

            audio.PlayOneShot(clip);
        }
    }
}
