using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Obstacle
{
    private Vector3 startPosition;


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
    }

    void Restart()
    {
        transform.position = startPosition;
        
        myBoxCollider2D.enabled = true;
        myrb2D.velocity = Vector2.zero;
    }

}
