using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// how fast does the player move?
    /// </summary>
    public float moveSpeed = 5f;
    /// <summary>
    /// how much force does the player jump with?
    /// </summary>
    public float jumpForce = 10f;
    /// <summary>
    /// is the player on the ground?
    /// </summary>
    public bool isGrounded;
    /// <summary>
    /// a holder for the rigidbody, which we will manipulate in order to move the player
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// how much health does the player have? i.e. how many hits can I take?
    /// </summary>
    public int health = 3;
    /// <summary>
    /// how often can they be damaged / how long are they invincible after a hit?
    /// </summary>
    public float damageCooldown = 1.5f;
    /// <summary>
    /// how long has it been since the last damage event?
    /// </summary>
    private float lastDamageTime = -Mathf.Infinity;
    /// <summary>
    /// the UI asset that holds our health text
    /// </summary>
    public TextMeshProUGUI healthText;

    private void Start()
    {
        // find the rigidbody of the player
        rb = GetComponent<Rigidbody2D>();

        // what if we don't get a rigidbody back?
        if (rb == null)
        {
            // we should pop an error!
            Debug.LogError("Player RB not found");
        }

        // update our health UI
        healthText.text = "Health = " + health;
    }

    // this is called once every 0.02 seconds, or 50 times per second. we generally want to use FixedUpdate for physics-based interactions.
    private void FixedUpdate()
    {
        // moving left and right by getting the Horizontal movement axis from the player's controls
        float moveInput = Input.GetAxis("Horizontal");
        // we are directly modifying the horizontal velocity of our rigidbody by setting rb.velocity.x to "moveInput * speed"!
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // jumping
        // if the Jump axis is > 0 (if we're pressing the Spacebar), AND if the player is grounded...
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            // then set the vertical velocity to the jump force instantaneously
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // when we begin colliding with another object...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // does the other object have the Ground tag?
        if (collision.gameObject.CompareTag("Ground"))
        {
            // if so, we're on the ground, so set isGrounded to true
            isGrounded = true;
        }
    }

    // when we stop colliding with another object...
    private void OnCollisionExit2D(Collision2D collision)
    {
        // does the other object have the ground tag?
        if (collision.gameObject.CompareTag("Ground"))
        {
            // if so, we've stopped touching the ground, so set isGrounded to false
            isGrounded = false;
        }
    }

    // a function for the player to be able to
    // take damage when the enemy touches them!
    // remember, we added the public int Health at the top.
    public void TakeDamage(int damageVal)
    {
        if(Time.time - damageCooldown >= lastDamageTime)
        {
            lastDamageTime = Time.time;

            health -= damageVal;
            // update the health UI
            healthText.text = "Health = " + health;

            Debug.Log("Health = " + health);

            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
                // Destroy(gameObject);
                Debug.Log("You died!");
            }
        }
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
}