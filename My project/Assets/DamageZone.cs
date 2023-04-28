using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DamageZone : MonoBehaviour
{
    public int zone_damage;
    public GameObject respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript playerH = collision.GetComponent<PlayerScript>();
        if (playerH != null)
        {
            playerH.PlayerHealth -= zone_damage;
            if (playerH.PlayerHealth <= 0)
            {
                playerH.transform.position = respawn.transform.position;
                playerH.PlayerHealth = 100;
            }
        }
    }
    

}
