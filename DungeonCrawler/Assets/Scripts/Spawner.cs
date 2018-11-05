using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    float passed;

    void Update()
    {
        passed += Time.deltaTime;

        if (passed > 2.0f)
        {
            GameObject created = Instantiate(enemy);
            created.transform.position = transform.position;
            passed = 0f;
        }
    }
}
