using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    /// <summary>
    /// The location, rotation, and scale of the player! IMPORTANT: WE NEED TO SET THIS IN THE EDITOR!
    /// </summary>
    public Transform player;
    /// <summary>
    /// how much delay the camera follows the player with
    /// </summary>
    public float smoothSpeed = 0.25f;
    /// <summary>
    /// The current camera velocity for smoothdamp. SET TO Vector3.zero AND DO NOT TOUCH!
    /// SmoothDamp will change this on its own thanks to the "ref" call.
    /// </summary>
    private Vector3 cameraVelocity = Vector3.zero;

    // late update runs AFTER every Update frame
    private void LateUpdate()
    {
        // if we have no player... (NOTE: DO NOT USE A SINGLE =. One = will set the player equal to null.
        // Two == will *check* if the player is null.
        if (player == null)
        {
            return;
        }

        // interpolate between the current position and the player
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        // then set the camera position to the target position we set above.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothSpeed);

        // the Lerp (Linear Interpolation) method works, but doesn't have much momentum or "weight" to it.
        //transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // this method simply locks the camera to the player, which can be slightly disorienting in some cases.
        // transform.position = targetPosition;
    }
}
