using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuckState : PlayerBaseState
{
    private float friction = 3f;
    public override void EnterState(PlayerStateManager player)
    {
        Vector3 lookDirection = player.rb.transform.right;
        float diveDirection = Mathf.Sign(lookDirection.x);
        Debug.Log(lookDirection);
        Vector2 diveForce = new Vector2(diveDirection * player.diveForce /2, player.diveForce /2);
        player.rb.velocity = diveForce;
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Mathf.Abs(player.rb.velocity.y) < 0.01f)
        {
            if (Mathf.Abs(player.rb.velocity.x) > 0.01f)
            {
                if (player.rb.transform.right.x == 1f)
                {
                    player.rb.velocityX -= friction * Time.deltaTime;
                }
                else
                {
                    player.rb.velocityX += friction * Time.deltaTime;
                }
            }
            else
            {
                player.changeState(player.idleState);
            }
        }
    }
}
