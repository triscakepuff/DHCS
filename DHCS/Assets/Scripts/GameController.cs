using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int startingHP = 1;
    private Vector2 startingPosition;
    private Vector2 currPosition;
    private Rigidbody2D rb;
    public int currHP;
    public float respawn_timer = 0.5f;
    private bool isDeathInProgress = false;
    void Start()
    {
        currHP = startingHP;
        startingPosition = transform.position;
       
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    

    public void Respawn()
    {
        currHP = startingHP;
        transform.position = startingPosition;
       
    }
}
