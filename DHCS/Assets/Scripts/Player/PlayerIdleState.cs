using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        float moveInput = Input.GetAxis("Horizontal");
        player.pc.Move(moveInput);
        if (Input.GetKey(KeyCode.Space))
        {
            player.changeState(player.duckState);
        }
    }
}
