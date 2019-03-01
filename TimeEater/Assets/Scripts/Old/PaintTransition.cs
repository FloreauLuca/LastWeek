using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTransition : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerCheck"))
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
