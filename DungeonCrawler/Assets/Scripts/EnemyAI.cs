using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent navMesh;
    Animation animation;
    float idleMagnitude = 0.3f;

    Vector3 idle = new Vector3(0.2f, 0.2f, 0.2f);

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(player.transform.position);

        if (navMesh.velocity.magnitude < idleMagnitude && !animation.IsPlaying("idle"))
        {
            animation.Play("idle");
        }
        else if (!animation.IsPlaying("walk"))
        {
            animation.Play("walk");
        }

    }

    void OnDisable()
    {
        navMesh.enabled = false;
    }
}
