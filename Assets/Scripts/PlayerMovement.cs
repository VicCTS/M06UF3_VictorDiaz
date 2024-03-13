using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    
    private float horizontalInput;

    public float movementSpeed = 5;
    public float jumpForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //transform.position = new Vector3 (-50, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        Movement();

        Jump();
    }


    void FixedUpdate()
    {
        //rigidbody2d.velocity = new Vector2(1 * movementSpeed, rigidbody2d.velocity.y);
        //rigidbody2d.AddForce(Vector2.right * 10);
        //rigidbody2d.MovePosition(new Vector2(-90, -4.9f));
        //rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(1, 0) * movementSpeed);
    }

    void Movement()
    {
        transform.position = new Vector3 (transform.position.x + horizontalInput * Time.deltaTime * movementSpeed, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(horizontalInput, 0) * Time.deltaTime * movementSpeed);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-90, -4.9f, 0), movementSpeed * Time.deltaTime);

        if(horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("IsWalking", true);
        }
        else if(horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }
}
