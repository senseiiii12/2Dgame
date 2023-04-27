using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawntime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTimer", spawntime, spawntime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTimer()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
