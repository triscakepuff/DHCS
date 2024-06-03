using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    Transform grapplePos;
    SpriteRenderer sr;
    GameObject character;
    float distance;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        grapplePos = GetComponent<Transform>();
        character = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (character != null)
        {
            distance = Vector2.Distance(grapplePos.position, character.transform.position);
            if (distance < 5)
            {
                sr.color = Color.red;
            }
            else
            {
                sr.color = Color.white;
            }
        }
        if (Input.GetMouseButtonDown(0)) 
        {
        if (character != null)
        {
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

    
}
