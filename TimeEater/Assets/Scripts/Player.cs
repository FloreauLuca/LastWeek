using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    
    private Rigidbody2D playerRb;
    private Animator animator;
    public bool mapMoving;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {       
        if (Input.GetKey(KeyCode.W))
        {
            playerRb.velocity = Vector2.up * playerSpeed;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            playerRb.velocity = Vector2.left * playerSpeed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            playerRb.velocity = Vector2.down * playerSpeed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            playerRb.velocity = Vector2.right * playerSpeed;
        }
        else
        {
            playerRb.velocity = Vector2.zero;
        }
    }
}