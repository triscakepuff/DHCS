using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject character = GameObject.FindWithTag("Player");
        if (character != null)
        {
            // Get the character's script
            PlayerStateManager playerStateManager = character.GetComponent<PlayerStateManager>();
            PlayerGrappleState pgs = playerStateManager.grappleState;
            if (playerStateManager != null)
            {
                // Call the changeState function with the desired newState parameter
                playerStateManager.changeState(pgs);
            }
        }
    }
}
