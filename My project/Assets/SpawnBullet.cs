using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnTimer", spawntime, spawntime);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnB();
        }
    }

    void SpawnB()
    {
        GameObject enemy = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
