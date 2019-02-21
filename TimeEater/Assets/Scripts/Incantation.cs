using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incantation : MonoBehaviour
{
    private bool filled = false;

    public bool Filled
    {
        get { return filled; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = transform.position;
            filled = true;
        }
    }


    void Restart()
    {
        filled = false;
    }

}
