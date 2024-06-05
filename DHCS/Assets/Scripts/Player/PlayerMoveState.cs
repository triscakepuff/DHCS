using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public bool isMoving = false;
    public float sprintSpeed = 9f;
    public float moveSpeed = 4.5f;
    public float currentSpeed;
  

    [Header ("Sprint")]
    public bool isSprinting = false;
    public float currentStamina = 100f;
    public float maxStamina = 100f;
    public float staminaDrainRate = 66f;
    public float staminaRegenRate = 30f;
    public bool isStaminaDepleted = false;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("ello from playermeovstaet");
        
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
        Debug.Log(currentStamina);
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
            

            if(Input.GetButton("Fire3") && currentStamina > 0f && !isStaminaDepleted)
            {
                isSprinting = true;
                currentStamina -= staminaDrainRate * Time.deltaTime;
                if(currentStamina < 0f)
                {
                    currentStamina = 0f;
                    isStaminaDepleted = true;
                }
                currentSpeed = sprintSpeed;
                Debug.Log("Pressed");
            }else 
            {
                isSprinting = false;
                if(currentStamina <= maxStamina)
                {
                    currentStamina += staminaRegenRate * Time.deltaTime;
                    if (currentStamina >= maxStamina)
                    {
                        currentStamina = maxStamina;
                        isStaminaDepleted = false;
                    }
                }
                
                currentSpeed = moveSpeed;
            }
                
            player.rb.velocity = new Vector2(moveInput * currentSpeed, player.rb.velocity.y);

            player.animator.SetFloat("Speed", absSpeed*currentSpeed);

            if (Input.GetButton("Jump"))
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