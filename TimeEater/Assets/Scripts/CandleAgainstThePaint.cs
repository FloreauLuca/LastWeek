using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using UnityEngine;

public class CandleAgainstThePaint : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Transform candleRespawn;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Paint"))
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
        
        else if (col.gameObject.CompareTag("Wall"))
        {
            col.transform.position = candleRespawn.position;
        }
    }
}