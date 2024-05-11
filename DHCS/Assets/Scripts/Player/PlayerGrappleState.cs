using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("PlayerGrappleState");
        Vector2 mousePos = (Vector2)player.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        player.lineRenderer.SetPosition(0, mousePos);
        player.lineRenderer.SetPosition(1, player.transform.position);
        player.distanceJoint.connectedAnchor = mousePos;
        player.distanceJoint.enabled = true;
        player.lineRenderer.enabled = true;
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            player.distanceJoint.enabled = false;
            player.lineRenderer.enabled = false;
            player.changeState(player.idleState);
        }
        if (player.distanceJoint.enabled)
        {
            player.lineRenderer.SetPosition(1, player.transform.position);
        }
    }
}
