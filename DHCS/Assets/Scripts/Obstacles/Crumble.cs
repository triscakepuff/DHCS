using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumble : MonoBehaviour
{
    public GameObject crumblingFloor;
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentTag = gameObject.tag;
        if(other.CompareTag("Player"))
        {
            
            Destroy(crumblingFloor, 1f);
        }  
    }
}
