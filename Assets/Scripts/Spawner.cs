using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
