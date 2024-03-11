using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    internal PlayerBaseState currentState;
    internal PlayerDuckState duckState = new PlayerDuckState();
    internal PlayerIdleState idleState = new PlayerIdleState();
    internal PlayerController pc;

    internal float diveForce = 10f;
    internal Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = new PlayerController(rb);
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void changeState(PlayerBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
