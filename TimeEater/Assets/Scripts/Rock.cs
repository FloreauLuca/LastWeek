using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Obstacle
{
    [SerializeField] public Location myLocation;

    private Vector3 startPosition;
    [SerializeField] private LayerMask raycastLayerMask;

    private bool iced = false;
    private Vector3 direction;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        startPosition = transform.position;
        GetComponent<Rigidbody2D>().isKinematic = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Restart") && GameManager.Instance.Player.PlayerLocation == myLocation)
        {
            Restart();
        }

        if (GameManager.Instance.Playermode)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;

        }


    }

    private void FixedUpdate()
    {
        if (iced)
        {
            if (UnMovable(direction))
            {
                direction = Vector3.zero;
            }
            else
            {
                transform.position += direction;
            }
        }
        else
        {
            direction = Vector3.zero;
            animator.SetFloat("XMove", direction.x);
            animator.SetFloat("YMove", direction.y);

        }

        if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {

            animator.SetFloat("XMove", GetComponent<Rigidbody2D>().velocity.x);
            animator.SetFloat("YMove", GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void Restart()
    {
        transform.position = startPosition;
        
        myBoxCollider2D.enabled = true;
        myrb2D.velocity = Vector2.zero;
    }


    public bool UnMovable(Vector3 orientation)
    {

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + orientation, myBoxCollider2D.size, 0, raycastLayerMask );
        bool detectWall = false;
        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.GetComponent<Obstacle>())
                {
                    detectWall = true;
                }
                else if (collider.GetComponent<Hole>())
                {
                    collider.GetComponent<Hole>().Collision(gameObject);
                    detectWall = false;
                }
                else if (collider.GetComponent<Ice>())
                {
                    direction = orientation;
                    iced = true;
                    //detectWall = true;
                }
                else
                {
                    detectWall = true;
                }
            }
        }
        else
        {
            transform.position += orientation;
            animator.SetFloat("XMove", orientation.x);
            animator.SetFloat("YMove", orientation.y);
            iced = false;
        }
        return detectWall;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerCheck"))
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerCheck"))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
