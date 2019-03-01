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

    protected Rigidbody2D myrb2D;
    protected BoxCollider2D myBoxCollider2D;

    
    protected void Start()
    {
        myrb2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected void FixedUpdate()
    {
        if (!myrb2D.IsTouching(GameManager.Instance.Player.GetComponent<BoxCollider2D>()))
        {
            myrb2D.isKinematic = true;
            fixe = true;
            myrb2D.velocity = Vector2.zero;
        }
        else
        {
            myrb2D.isKinematic = false;
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
