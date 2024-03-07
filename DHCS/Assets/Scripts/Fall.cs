using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject crumblingFloor;
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
}
