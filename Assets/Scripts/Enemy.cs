using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public Animator animator;
    public BoxCollider2D boxCollider2D;

    private SFXManager sFXManager;
    private GameManager gameManager;

    public float movementSpeed = 5;
    private int movementDirection = 1;

    public AudioClip deathSFX;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        sFXManager = GameObject.Find("SFX Manager").GetComponent<SFXManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(movementDirection * movementSpeed, rigidbody2D.velocity.y);
    }

    public void Death()
    {
        movementDirection = 0;

        boxCollider2D.enabled = false;
        animator.SetTrigger("isDeath");

        sFXManager.PlaySFX(deathSFX);

        Destroy(gameObject, 1f);
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
            /*
            Animator playerAnimator = collision.gameObject.GetComponent<PlayerMovement>().animator;
            BoxCollider2D playerCollider = collision.gameObject.GetComponent<PlayerMovement>().boxCollider2D;
            BoxCollider2D sensorCollider = collision.gameObject.GetComponent<PlayerMovement>().sensorCollider;
            
            playerCollider.enabled = false;
            sensorCollider.enabled = false;
            playerAnimator.SetTrigger("IsDead");

            Destroy(collision.gameObject, 1f);
            */

            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            playerMovement.Death();
        }

        if(collision.gameObject.layer == 7)
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
        
    }

    void OnBecameVisible()
    {
        gameManager.enemiesInScreen.Add(gameObject);
    }

    void OnBecameInvisible()
    {
        gameManager.enemiesInScreen.Remove(gameObject);
    }
}
