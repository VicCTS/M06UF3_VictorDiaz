using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public Animator animator;
    public BoxCollider2D boxCollider2D;

    public float movementSpeed = 5;
    private int movementDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(movementDirection * movementSpeed, rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tuberias")
        {
            if(movementDirection == 1)
            {
                movementDirection = -1;
            }
            else if(movementDirection == -1)
            {
                movementDirection = 1;
            }
        }

        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
