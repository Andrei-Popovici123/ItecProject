using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoofTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("a mers");
            GetComponent<TilemapRenderer>().enabled = false;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("a mers");
            GetComponent<TilemapRenderer>().enabled = true;
        }
        
    }
}
