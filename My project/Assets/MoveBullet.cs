using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speedBullet;
    PlayerScript player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speedBullet);
    }
}