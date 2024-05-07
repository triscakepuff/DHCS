using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int startingHP = 1;
    private PlayerStateManager movement;
    private Vector2 startingPosition;
    private Vector2 currPosition;
    public int currHP;
    void Start()
    {
        currHP = startingHP;
        startingPosition = transform.position;
        movement = GetComponent<PlayerStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currHP == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        movement.enabled = false;
        if(Input.GetMouseButtonDown(0))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        movement.enabled = true;
        transform.position = startingPosition;
    }
}
