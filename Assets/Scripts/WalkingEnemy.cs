using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    // how fast is the enemy walking?
    public float moveSpeed = 2f;
    // we need a location to check the ground from. we're doing this from an empty game object, a child of the enemy, slightly in front of it. setting this in editor.
    public Transform groundCheck;
    // what layers do we check for for our ground check? setting this in editor.
    public LayerMask groundLayer;
    // are we moving right? (admittedly, we aren't actually using this variable. however, we could definitely program some components
    private bool isMovingRight = true;

    // once per frame
    private void Update()
    {
        // translate means we're moving. because we're doing this once per frame, we multiply by Time.deltaTime, which applies the time between frames. this is like using FixedUpdate.
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // cast a ray from the groundCheck position straight down for 1 unit, then store the information of the hit to a variable.
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);

        // if the hit does not have another collider that the raycast contacted (i.e. if the ground isn't there)...
        if (!groundInfo.collider)
        {
            // then we need to turn around! run the Flip function, described below!
            Flip();
        }
    }

    // we need a function for turning the player around for movement, the sprite facing, and the ground check!
    void Flip()
    {
        // say that the object is moving in the opposite direction it was just facing
        isMovingRight = !isMovingRight;

        // get the local scale of the enemy's transform, and save it...
        Vector3 localScale = transform.localScale;
        // ...then multiply the horizontal value of the scale by negative 1, which will effectively flip it backwards...
        localScale.x *= -1;
        // ...THEN apply this modified localScale to the localScale of the transform! we need to do this directly because we can't modify transform.localScale.x directly.
        transform.localScale = localScale;

        // make the enemy flip movement directions by inversing its movement speed!
        moveSpeed *= -1;
    }

    // on EVERY frame that the something is within the trigger of the Enemy (which we set in the editor and made it ignore the Ground and Enemy layers)...
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ...see if that "thing" has the player tag! if it does...
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy(collision.gameObject);

            // ...get the player's movement script and save it to a variable! then...
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            // ...call the Damage function directly from the PlayerMovement script!
            player.Damaged(1);
        }
    }


    // deprecated code for doing what we now do with the trigger!
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy(collision.gameObject);

            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

            player.Damaged(1);
        }
    }
    */
}
