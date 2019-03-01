using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labyrinth : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    
    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.CompareTag("PlayerCheck"))
        {
            col.transform.position = respawnPoint.position;
        }
    }
}
