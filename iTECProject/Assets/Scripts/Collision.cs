using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    
    private void OnCollisionEnter2D()
    {
        Debug.Log("ball");
        if (GetComponent<SpriteRenderer>().enabled== false)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            Debug.Log("u drowned stubid");
            GetComponent<SpriteRenderer>().enabled = false;
        
    }
}