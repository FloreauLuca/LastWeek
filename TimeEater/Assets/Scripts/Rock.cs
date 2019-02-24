using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Obstacle
{
    private Vector3 startPosition;
    [SerializeField] private LayerMask raycastLayerMask;

    private bool iced = false;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Restart"))
        {
            Restart();
        }

        if (iced)
        {
            if (UnMovable(direction))
            {
                direction = Vector3.zero;
            }
        }
        else
        {
            //direction = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (iced)
        {
            transform.position += direction;
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
        Debug.Log(colliders);
        foreach (var collider in colliders)
        {

            if (collider.GetComponent<Obstacle>())
            {
                return true;
            }
            else if (collider.GetComponent<Hole>())
            {
                collider.GetComponent<Hole>().Collision(gameObject);
                return false;
            }
            else if (collider.GetComponent<Ice>())
            {
                transform.position += orientation;
                direction = orientation;
                iced = true;
                Debug.Log("Iced");
                return false;
            }
            else
            {
                return true;
            }
        }
        if (iced)
        {
            transform.position += orientation;
            iced = false;
            Debug.Log("UnIced");
            return false;
        }
        else
        {
            transform.position += orientation;
            Debug.Log("UnIced");
            return false;

        }
    }

}
