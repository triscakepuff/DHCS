using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject crumblingFloor;
    private GameController HP;
   
    void Start()
    {
        GameObject Theodore = GameObject.Find("Theodore");
        if (Theodore != null)
        {
            // Get the GameController script attached to Theodore
            HP = Theodore.GetComponent<GameController>();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentTag = gameObject.tag;
        if(other.CompareTag("Player"))
        {
            obstacle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
          
            
        }   
    }
   
     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT!");
            if(HP != null)
            {
                HP.currHP--;
            }
        }
    }
}
