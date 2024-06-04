using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            isGrounded = true;
        }

        if(collider.gameObject.layer == 7)
        {
            /*
            Animator enemyAnimator = collider.gameObject.GetComponent<Enemy>().animator;
            BoxCollider2D enemyCollider = collider.gameObject.GetComponent<Enemy>().boxCollider2D;

            enemyAnimator.SetTrigger("IsDeath");
            enemyCollider.enabled = false;

            Destroy(collider.gameObject, 1f);
            */

            Enemy enemy = collider.gameObject.GetComponent<Enemy>();

            enemy.Death();
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }
}
