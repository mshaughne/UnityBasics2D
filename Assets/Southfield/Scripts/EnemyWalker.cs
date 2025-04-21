using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    /// <summary>
    /// how fast the enemy moves
    /// </summary>
    public float moveSpeed = 2f;
    /// <summary>
    /// the location from which we use a raycast to find the ground
    /// </summary>
    public Transform groundCheck;
    /// <summary>
    /// what layers are we counting as the ground?
    /// </summary>
    public LayerMask groundLayers;
 
    // Update is called once per frame
    void Update()
    {
        // here, we are manually shifting the enemy's position,
        // instead of changing their velocity. both have their uses
        // for different types of movement, but here, either would work.
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        // reminder, we're not in FixedUpdate, so we're going to use deltaTime!

        /* a little complex here. we're shooting a raycast, an 
         * instantaneous line that goes from point A, in direction B,
         * for C units of length, only contacting objects on the layers in
         * D layermask. then, it will return information what it did
         * or did not hit.*/
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayers);

        // find out if "hit", the Raycast2D's hit information (like the
        // collision stuff), contains a collider. if it doesn't, it didn't
        // touch the ground, and we need to turn around.
        if(!hit.collider)
        {
            // call our custom function, flip!
            Flip();
        }
    }

    // here we are going to flip the character by inverting their X scale, 
    // which flips the sprite, then setting the movespeed to negative,
    // which will make the enemy move in the other direction.
    void Flip()
    {
        // get the scale of the gameobject relative to its parent
        // (hence, localScale)
        Vector3 localScalePlaceholder = transform.localScale;

        // flips the scale horizontally (which flips sprites)
        localScalePlaceholder.x *= -1;

        // setting the local scale to our newly modified placeholder
        transform.localScale = localScalePlaceholder;

        // move in the other direction (so if we move right at 2 u/s,
        // and we *= -1, then we move right at -2 u/s, aka left at 2 u/s)
        moveSpeed *= -1;
    }


    // for every frame that something is in the trigger, do the following!
    // (triggers are like colliders that don't block things from entering,
    // so they just detect things inside of them)
    private void OnTriggerStay2D(Collider2D collision)
    {
        // if the colliding object has the Player tag...
        if(collision.gameObject.CompareTag("Player"))
        {
            // we need to damage the player!
        }
    }
}
