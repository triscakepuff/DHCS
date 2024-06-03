using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("PlayerGrappleState");
        //help pls change wherever the line is aiming from your mouse position to the position of the grapple point
        Vector2 mousePos = (Vector2)player.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //i've already changed the code in GrapplePoint.cs from void OnMouseDown to if (Input.GetMouseButtonDown(0))
        //the player does not need to play osu to grapple, simply click and they will grapple to the nearest grapple point
        player.lineRenderer.SetPosition(0, mousePos);
        player.lineRenderer.SetPosition(1, player.transform.position);
        player.distanceJoint.connectedAnchor = mousePos;
        player.distanceJoint.enabled = true;
        player.lineRenderer.enabled = true;
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.distanceJoint.enabled = false;
        player.lineRenderer.enabled = false;

        Vector2 diveForce = new Vector2(player.rb.velocity.x * 0.5f, player.rb.velocity.y * 0.5f);
        player.rb.velocity += diveForce;
        Debug.Log("velocity X: " + player.rb.velocity.x);
        Debug.Log("velocity Y: " + player.rb.velocity.y);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        float horizontalDirection = Mathf.Sign(player.rb.velocityX);
        if (horizontalDirection > 0)
        {
            player.transform.right = Vector2.right;
        }
        else
        {
            player.transform.right = Vector2.left; 
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            player.changeState(player.fallState);
        }
        if (player.distanceJoint.enabled)
        {
            player.lineRenderer.SetPosition(1, player.transform.position);
        }
    }
}
