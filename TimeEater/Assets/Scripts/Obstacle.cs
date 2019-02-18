using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private bool fixe = false;
    public bool Fixe
    {
        get { return fixe; }
        set { fixe = value; }
    }

    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    
    void FixedUpdate()
    {
        if (!rigidbody2D.IsTouching(GameManager.Instance.Player.GetComponent<BoxCollider2D>()))
        {
            rigidbody2D.isKinematic = true;
            fixe = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            rigidbody2D.isKinematic = false;
            fixe = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Obstacle>())
        {
            fixe = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Obstacle>())
        {
            fixe = false;
        }
    }
}
