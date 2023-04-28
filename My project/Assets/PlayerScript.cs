using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float horizontal;
    private CapsuleCollider2D capsuleCollider2D;
    private bool isGrounded;
    int countJumps;
    public int countJumpsValue;
    public int PlayerHealth = 100;

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
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        FixedUpdate();
        flip();
        checkIsGround();
        jump();
        shoot();
        
        
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
    }
    private void flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
    }

    private void jump()
    {
        if (isGrounded)
        {
            countJumps = countJumpsValue;
        }
        if(Input.GetKeyDown(KeyCode.Space) && countJumps > 0)
        {   
            rigidBody2D.AddForce(Vector2.up * jumpForse);
            countJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && countJumps == 0 && isGrounded)
        {
            rigidBody2D.AddForce(Vector2.up * jumpForse);
        }
    }

    private void checkIsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.down, capsuleCollider2D.bounds.extents.y + 0.1f);
        if (hit.collider != null)
        {
            isGrounded = true;
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
