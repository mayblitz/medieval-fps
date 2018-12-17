using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    GameObject player;
    float passed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 15)
        {
            passed += Time.deltaTime;

            if (passed > 30.0f)
            {
                GameObject created = Instantiate(enemy);
                created.transform.position = transform.position;
                passed = 0f;
            }
        }
    }
}
