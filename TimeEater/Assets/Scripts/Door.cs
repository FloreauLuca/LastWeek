using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform cameraTranslation;
    [SerializeField] private Transform playerTranslation;

    [SerializeField] private bool closed;

    public bool Closed
    {
        get { return closed; }
        set
        {
            closed = value;
            if (closed)
            {
                boxCollider2D.isTrigger = false;
            }
            else
            {
                boxCollider2D.isTrigger = true;

            }
        }
    }


    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (closed)
        {
            boxCollider2D.isTrigger = false;
        }
        else
        {
            boxCollider2D.isTrigger = true;

        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck")
        {
            ChangeRoom();
        }
    }
 
    private void ChangeRoom()
    { 
        playerTranslation.position = new Vector3(Convert.ToSingle(Math.Round(playerTranslation.position.x - 0.5f) + 0.5f), Convert.ToSingle(Math.Round(playerTranslation.position.y - 0.5f) + 0.5f), 0);
        GameManager.Instance.Player.transform.position = playerTranslation.position;
        GameManager.Instance.Player.GetComponent<Player>().StartPosition = playerTranslation.position;
        GameManager.Instance.Camera.transform.position = cameraTranslation.position;

    }
}
