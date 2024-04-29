using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    
    internal PlayerBaseState currentState;
    internal PlayerDuckState duckState = new PlayerDuckState();
    internal PlayerIdleState idleState = new PlayerIdleState();
    internal PlayerHideState hideState = new PlayerHideState();
    internal PlayerMoveState moveState = new PlayerMoveState();

    internal float diveForce = 10f;
    internal GameObject detectedTable = null;
    internal Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        currentState = idleState;
        currentState.EnterState(this);
      
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

       if (currentState==duckState) animator.SetBool("Dive", true);
       else if (currentState!=duckState) animator.SetBool("Dive", false);
       
    }

    public void changeState(PlayerBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        detectedTable = other.gameObject;
        if (Input.GetKey(KeyCode.E) && currentState == idleState)
        {
            string currentTag = gameObject.tag;
            if (other.CompareTag("Table"))
            {
                changeState(hideState);
            }
        }
    }
}
