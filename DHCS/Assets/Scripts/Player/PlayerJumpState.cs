using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        //player.rb.velocity = Vector2.zero;
        //player.animator.SetBool("Dive", true);
        Debug.Log("ello from playerjumpstaet");
        Vector2 diveForce = new Vector2(0f, player.diveForce / 2);
        player.rb.velocity += diveForce;
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.changeState(player.duckState);
        }

        if (Mathf.Abs(player.rb.velocityY) < 0.01f)
        {
            player.changeState(player.idleState);
        }
    }
}
