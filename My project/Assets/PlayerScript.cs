using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float horizontal;
    private bool isGrounded;
    int countJumps = 0;

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
        jump();
        checkIsGround();
        Debug.Log(countJumps);
        
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
    }
    private void flip()
    {
        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void jump()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            countJumps++;
            rigidBody2D.AddForce(Vector2.up * jumpForse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && rigidBody2D.velocity.y > 0f && countJumps < 2)
        {
            countJumps++;
            rigidBody2D.AddForce(Vector2.up * jumpForse);
            
        }
    }

    private void checkIsGround()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            isGrounded = true;
            countJumps = 0;
        }
        else
            isGrounded = false;
    }

    private void shoot()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(bullet, shootPosition.position, transform.rotation);
        }
    }


}
