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

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            Collision(other.gameObject);
        }
    }

    public virtual void Collision(GameObject other)
    {
        if (other.CompareTag("Rock"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<Rock>().enabled = false;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    protected virtual void Restart()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
