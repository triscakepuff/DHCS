using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private GameController HP;
    internal PlayerBaseState currentState;
    internal Camera mainCamera;
    internal LineRenderer lineRenderer;
    internal DistanceJoint2D distanceJoint;
    public BoxCollider2D groundCheck;
    
    public LayerMask groundMask;

    public bool grounded;

    //States
    internal PlayerDuckState duckState = new PlayerDuckState();
    internal PlayerIdleState idleState = new PlayerIdleState();
    internal PlayerHideState hideState = new PlayerHideState();
    internal PlayerMoveState moveState = new PlayerMoveState();
    internal PlayerDeathState deathState = new PlayerDeathState();
    internal PlayerGrappleState grappleState = new PlayerGrappleState();
    internal PlayerFallState fallState = new PlayerFallState();
    internal PlayerJumpState jumpState = new PlayerJumpState();
    //
    internal float diveForce = 13f;
    internal GameObject detectedTable = null;
    

    
    internal Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        HP = GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        mainCamera = Camera.main;
        Cursor.visible = true;
        currentState = idleState;
        currentState.EnterState(this);
      
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if(HP != null)
        {
            if(HP.currHP == 0)
            {
                changeState(deathState);
                animator.SetBool("Death", true);
            }
            else if(HP.currHP == 1)
            {
                animator.SetBool("Death", false);
            }
        }

        if(Input.GetKeyDown(KeyCode.CapsLock))
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

      
       
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
        if (Input.GetKey(KeyCode.E))
        {
            string currentTag = gameObject.tag;
            if (other.CompareTag("Table"))
            {
                changeState(hideState);
            }
        }
    }

    void FixedUpdate()
    {
        CheckGround();

        if(grounded)
        {
            animator.SetBool("Grounded", true);
        }
        else if(!grounded)
        {
            animator.SetBool("Grounded", false);
        }
    }

    void CheckGround(){

        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;



    }

    



}
