using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // the location, rotation, and scale of the player
    public Transform player;
    // how much smoothing the camera uses when tracking the player
    public float smoothSpeed = 0.125f;
    // how much to offset the camera by on the player!
    public Vector3 offset;
    // a dummy variable used by the SmoothDamp function, which will automatically modify it.
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // if we can't get the player for some reason
        if (player == null)
        {
            // stop running the code
            return;
        }

        // deprecated code (we aren't using this part)
        //Vector3 desiredPosition = player.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        //transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);

        // we want to find the player on the X and Y axes, not Z (because the camera needs to be at a different depth than the player!)
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        // then, we want to SMOOTHLY move over to the position we found!
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
