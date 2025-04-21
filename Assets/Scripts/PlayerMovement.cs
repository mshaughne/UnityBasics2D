using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // a holder for the rigidbody, which we will manipulate in order to move the player
    private Rigidbody2D rb;
    // is the player on the ground?
    private bool isGrounded;
    // how fast is the player moving?
    public float speed = 5f;
    // how high are they jumping / how much force do they jump with?
    public float jumpForce = 10f;
    // how much health do they have?
    public int health = 3;
    // how often can they be damaged / how long are they invincible after a hit?
    public float damageCooldown = 3f;
    // how long has it been since the last damage event?
    private float lastDamageTime = -Mathf.Infinity;

    // the text field that shows our player's health
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // automatically assign the rigidbody on startup
        rb = GetComponent<Rigidbody2D>();

        healthText.text = "Health = " + health;
    }

    // Update is called once per 0.02 seconds (50x per second)
    void FixedUpdate()
    {
        // moving left and right by getting the Horizontal movement axis
        float moveInput = Input.GetAxis("Horizontal");
        // we are directly relating our horizontal velocity of our rigidbody by setting rb.velocity.x to "moveInput * speed"!
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // jumping
        // if the Jump axis is > 0 (if we're pressing the Spacebar), AND if the player is grounded...
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            // then set the vertical velocity to the jump force instantaneously
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // sprint button
        // if we hold Fire1 (Left Control), then double the move speed, but put it back when we're done
        if(Input.GetButton("Fire1"))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // when we start touching another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if it has the ground tag. if it does...
        if (collision.gameObject.CompareTag("Ground"))
        {
            // ...then set isGrounded to true!
            isGrounded = true;
        }
    }

    // when we STOP touching another collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        // is the other object tagged with Ground? if so...
        if (collision.gameObject.CompareTag("Ground"))
        {
            // then set isGrounded to false, because we stopped touching the ground!
            isGrounded = false;
        }
    }

    public void Damaged(int damageVal)
    {
        // if the difference between current time and the last
        // time we were damaged >= our damage cooldown
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            // take damage
            health -= damageVal;
            // set a new time for when we were last damaged
            lastDamageTime = Time.time;

            // report that we were damaged
            Debug.Log("Took Damage! Health = " + health);
        }

        healthText.text = "Health = " + health;

        // if we have no health
        if (health <= 0)
        {
            healthText.text = "You Died!";
            // destroy the player (bad solution unless we're resetting the whole level!)
            // Destroy(gameObject);

            SceneManager.LoadScene("GameOverScene");
        }


        // deprecated code (nothing else past here)
        /*health -= damageVal;

        Debug.Log("Health = " + health);
        
        if (health <= 0)
        {
            // something to kill the player
            Destroy(gameObject);
        }*/
    }
}
