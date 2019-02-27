using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incantation : Hole
{
    private bool filled = false;

    public bool Filled
    {
        get { return filled; }
    }


    public override void Collision(GameObject other)
    {
        if (other.CompareTag("Crystal"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = transform.position;
            GetComponent<BoxCollider2D>().enabled = true;
            filled = true;
        }
    }


    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            Collision(other.gameObject);
        }
    }



    protected override void Restart()
    {
        base.Restart();
        filled = false;
    }

}
