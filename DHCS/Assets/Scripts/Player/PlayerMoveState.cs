using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public bool isMoving = false;
    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("ello from playermeovstaet");
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        float moveInput = Input.GetAxis("Horizontal");

        float absSpeed = Mathf.Abs(moveInput);
        player.animator.SetFloat("Speed", absSpeed);
        
        if (moveInput != 0)
        {
            

            if (moveInput > 0)
            {
                player.rb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (moveInput < 0)
            {
                player.rb.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
                
            player.rb.velocity = new Vector2(moveInput * currentSpeed, player.rb.velocity.y);

            player.animator.SetFloat("Speed", absSpeed*currentSpeed);

            if (Input.GetKey(KeyCode.Space))
            {
                player.changeState(player.jumpState);
                player.animator.SetFloat("Speed", 0);
            }
        }
        else
        { 
            player.changeState(player.idleState);            
        }
    }
}