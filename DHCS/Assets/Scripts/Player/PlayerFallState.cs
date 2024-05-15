using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private float friction = 20f;
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.SetBool("Dive", true);
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.animator.SetBool("Dive", false);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Mathf.Abs(player.rb.velocityY) < 0.01f)
        {
            if (player.rb.transform.right.x == 1f)
            {
                if (player.rb.velocityX > 0.01f)
                {
                    player.rb.velocityX -= friction * Time.deltaTime;
                }
                else
                {
                    player.changeState(player.idleState);
                }
            }
            else
            {
                if (player.rb.velocityX < -0.01f)
                {
                    player.rb.velocityX += friction * Time.deltaTime;
                }
                else
                {
                    player.changeState(player.idleState);
                }
            }
        }
    }
}

