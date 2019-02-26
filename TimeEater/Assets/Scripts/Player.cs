using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Location playerLocation = Location.ROOM0;

    public Location PlayerLocation
    {
        get { return playerLocation; }
        set { playerLocation = value; }
    }

    

    [SerializeField] private bool casePercase = true;

    public bool CasePercase
    {
        get { return casePercase; }
        set { casePercase = value; }
    }

    
    [SerializeField] private LayerMask raycastLayerMask;

    [SerializeField] private float playerSpeed;
    private int timerspeed = 0;


    [SerializeField] private Vector2 scale;

    private Rigidbody2D playerRb;
    private BoxCollider2D box;
    private Animator animator;

    private Vector3 direction;

    [SerializeField] private GameObject lifeText;
    [SerializeField] private int life;

    private Vector3 startPosition;

    public Vector3 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }

    public int Life
    {
        get { return life; }
        set
        {
            life = value;
            lifeText.GetComponent<TextMeshProUGUI>().text = "Life : " + life;
        }
    }

    private bool iced = false;
    public bool Iced
    {
        get { return iced; }
        set { iced = value; }
    }

    private bool invincible = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        lifeText.GetComponent<TextMeshProUGUI>().text = "Life : " + life;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (casePercase)
        {
           
                if (!Iced || direction == Vector3.zero)
                {

                    if (Input.GetButtonDown("Right"))
                    {
                        direction = Vector3.right * scale;
                        animator.SetInteger("Move", 2);
                        if (DetectWall(direction))
                        {
                            direction = Vector2.zero;
                        }
                    }
                    else if (Input.GetButtonDown("Left"))
                    {
                        direction = Vector3.left * scale;
                        animator.SetInteger("Move", 4);

                    if (DetectWall(direction))
                        {
                            direction = Vector2.zero;
                        }
                    }
                    else if (Input.GetButtonDown("Up"))
                    {
                        direction = Vector3.up * scale;
                        animator.SetInteger("Move", 1);

                    if (DetectWall(direction))
                        {
                            direction = Vector2.zero;
                        }
                    }
                    else if (Input.GetButtonDown("Down"))
                    {
                        direction = Vector3.down * scale;
                        animator.SetInteger("Move", 3);

                    if (DetectWall(direction))
                        {
                            direction = Vector2.zero;
                        }
                    }
                    
            }
                else
                {
                    if (DetectWall(direction))
                    {
                        direction = Vector3.zero;
                    }
                }
        }
        else
        {

            if (!Iced || playerRb.velocity == Vector2.zero)
            {
                if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
                {
                    direction = (Vector3.up * Input.GetAxisRaw("Vertical")) * playerSpeed;
                    animator.SetInteger("Move", 2 - Math.Sign(Input.GetAxisRaw("Vertical")));

                }
                else if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = (Vector3.right * Input.GetAxisRaw("Horizontal")) * playerSpeed;

                    animator.SetInteger("Move", 3 - Math.Sign(Input.GetAxisRaw("Horizontal")));
                }
                else
                {
                    direction = Vector3.zero;

                    animator.SetInteger("Move",0);
                }
            }

        }

        if (GameManager.Instance.Playermode)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;

        }

        if (Input.GetButtonDown("Restart"))
        {
            Restart();
        }
    }

    void Restart()
    {
        transform.position = startPosition;
    }


    void FixedUpdate()
    {       /*
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
        */
        timerspeed++;
        if (timerspeed >= playerSpeed)
        {
            timerspeed = 0;

            if (casePercase)
            {
                if (direction != Vector3.zero)
                {

                    animator.SetBool("Walk", true);
                }

                transform.position += direction;
                    if (!Iced)
                    {
                        direction = Vector3.zero;
                    }
            }
            else
            {
                playerRb.velocity = direction;

                if (direction != Vector3.zero)
                {

                    animator.SetBool("Walk", true);
                }

            }
        }

        if (GameManager.Instance.bossMode)
        {
            lifeText.SetActive(true);

        }
        else
        {
            lifeText.SetActive(false);
        }
    }

    public void InvincibilityStart()
    {
        if (!invincible)
        {
            Life -= 1;
            if (life <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
        StartCoroutine(Invincibility());
        
    }

    public IEnumerator Invincibility()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        invincible = true;
        yield return new WaitForSeconds(1);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        invincible = false;
    }


    public bool DetectWall(Vector2 orientation)
    {

        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2) transform.position + orientation, box.size * transform.localScale, 0, raycastLayerMask);
        Debug.Log((Vector2)transform.position + orientation);
        bool detectWall = false;
        if (colliders.Length>0)
        { 
        foreach (var collider in colliders)
        {
            Debug.Log(collider.gameObject);

            if (collider.GetComponent<Rock>())
            {
                detectWall = collider.GetComponent<Rock>().UnMovable(orientation);
            }
            else if (collider.GetComponent<Ice>())
            {
                Iced = true;
            }
            else if (collider.GetComponent<BoxCollider2D>())
            {
                if (collider.GetComponent<BoxCollider2D>().isTrigger)
                {
                    detectWall = false;
                }
                else
                {
                    detectWall = true;
                }
            } else
            {
                detectWall = true;
            }

        }

        }
        else
        {
            Iced = false;
        }
        return detectWall;
    }
}