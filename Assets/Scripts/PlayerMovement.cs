using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public Animator animator;
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D sensorCollider;

    private GroundSensor groundSensor;
    private SFXManager sFXManager;
    private BGMManager bGMManager;
    private SceneLoader sceneLoader;
    
    private float horizontalInput;

    public float movementSpeed = 5;
    public float jumpForce = 15;

    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    public AudioClip shootSFX;

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundSensor = GetComponentInChildren<GroundSensor>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        sFXManager = GameObject.Find("SFX Manager").GetComponent<SFXManager>();
        bGMManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();

        //transform.position = new Vector3 (-50, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        Movement();

        Jump();

        Shoot();
    }


    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontalInput * movementSpeed, rigidbody2d.velocity.y);
        //rigidbody2d.AddForce(Vector2.right * 10);
        //rigidbody2d.MovePosition(new Vector2(-90, -4.9f));
        //rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(1, 0) * movementSpeed);
    }

    void Movement()
    {
        //transform.position = new Vector3 (transform.position.x + horizontalInput * Time.deltaTime * movementSpeed, transform.position.y, transform.position.z);
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
        if(Input.GetButtonDown("Jump") && groundSensor.isGrounded)
        {
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            sFXManager.PlaySFX(jumpSFX);
        }

        animator.SetBool("IsJumping", !groundSensor.isGrounded);
    }

    public void Death()
    {
        boxCollider2D.enabled = false;
        sensorCollider.enabled = false;
        animator.SetTrigger("IsDead");

        bGMManager.StopBGM();
        sFXManager.PlaySFX(deathSFX);

        Destroy(gameObject, 1f);
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            sFXManager.PlaySFX(shootSFX);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Finish Line")
        {
            sceneLoader.LoadNextLevel();
        }
    }
}
