using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.rb.velocityX = 0;
        Debug.Log("ello from idel staet");
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        float moveInput = Input.GetAxis("Horizontal");
       
        if (Input.GetKey(KeyCode.Space))
        {
            player.changeState(player.duckState);
        }    

        if (moveInput != 0)
        {
            player.changeState(player.moveState);
        }
        
    }
}
