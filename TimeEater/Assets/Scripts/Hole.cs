using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Restart"))
        {
            Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = transform.position;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void Restart()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
