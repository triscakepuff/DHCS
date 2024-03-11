using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float sprintSpeed = 10f;

    public PlayerController(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public void Move(float moveInput)
    {
        if (moveInput > 0)
        {
            rb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (moveInput < 0)
        {
            rb.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
    }
}