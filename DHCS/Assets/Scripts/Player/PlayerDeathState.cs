using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    private GameController HP;
    private float time;
    public override void EnterState(PlayerStateManager player)
    {
        HP = player.GetComponent<GameController>();
       
    }

    public override void ExitState(PlayerStateManager player)
    {
      
    }

    public override void UpdateState(PlayerStateManager player)
    {
        time += Time.deltaTime;
        if(time < 2f)
        {
             player.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            HP.Respawn();
            player.rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            player.changeState(player.idleState);
        }

    }
    
   
}

