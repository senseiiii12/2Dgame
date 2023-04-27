using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float horizontal;
    private bool isGrounded;

    [SerializeField]
    private float speed, jumpForse;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shootPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        FixedUpdate();
        flip();
        
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
    }
    private void flip()
    {
        
    }


}
