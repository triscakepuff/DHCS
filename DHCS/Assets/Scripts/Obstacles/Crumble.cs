using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumble : MonoBehaviour
{
    public GameObject crumblingFloor;
    private PlayerStateManager player;

    void Start()
    {
        GameObject Theodore = GameObject.Find("Theodore");
       
        if (Theodore != null)
        {
            // Get the GameController script attached to Theodore
            player = Theodore.GetComponent<PlayerStateManager>();
            
        }
    }
    void Update()
    {
       Debug.Log(player.moveState.currentSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the collision involves a specific tag
        if (collision.CompareTag("Player"))
        {
           
            if(player.moveState.currentSpeed > 4.5f)
                Destroy(crumblingFloor, 0.1f);
        }
    }
}
