using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;

    public Vector3 TargetPosition
    {
        get { return targetPosition; }
        set { targetPosition = value; }
    }
    private Vector3 initialPosition;

    [SerializeField] private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField] private bool circle;

    public bool Circle
    {
        get { return circle; }
        set { circle = value; }
    }


    [SerializeField] private float timeBeforeDestroy;


    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) <= 0.1)
        {
            if (circle)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            rigidbody2D.velocity = Vector3.Normalize(targetPosition - initialPosition) * speed;
        }

        if (timeBeforeDestroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeBeforeDestroy -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCheck"))
        {
            Destroy(gameObject);
            other.GetComponent<Player>().InvincibilityStart();
        }
    }
}
