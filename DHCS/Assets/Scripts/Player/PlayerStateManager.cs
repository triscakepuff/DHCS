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

    //States
    internal PlayerDuckState duckState = new PlayerDuckState();
    internal PlayerIdleState idleState = new PlayerIdleState();
    internal PlayerHideState hideState = new PlayerHideState();
    internal PlayerMoveState moveState = new PlayerMoveState();
    internal PlayerDeathState deathState = new PlayerDeathState();
    internal PlayerGrappleState grappleState = new PlayerGrappleState();
    //
    internal float diveForce = 10f;
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
        if(HP.currHP == 0)
        {
            changeState(deathState);
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
