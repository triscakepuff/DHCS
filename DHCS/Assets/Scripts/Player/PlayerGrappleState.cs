using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("PlayerGrappleState");
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.changeState(player.idleState);
    }
}
