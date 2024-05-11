using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    Transform grapplePos;
    private void Start()
    {
        grapplePos = GetComponent<Transform>();
    }
    void OnMouseDown()
    {
        GameObject character = GameObject.FindWithTag("Player");
        if (character != null)
        {
            float distance = Vector2.Distance(grapplePos.position, character.transform.position);
            if(distance < 5)
            {
                PlayerStateManager playerStateManager = character.GetComponent<PlayerStateManager>();
                PlayerGrappleState pgs = playerStateManager.grappleState;
                if (playerStateManager != null)
                {
                    playerStateManager.changeState(pgs);
                }
            }
        }
    }
}
