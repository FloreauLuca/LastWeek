using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] public Location myLocation;

    [SerializeField] protected GameObject particule;

    protected AudioSource audioSource;

    [SerializeField] protected AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Restart") && GameManager.Instance.Player.PlayerLocation == myLocation)
        {
            Restart();
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            Collision(other.gameObject);
        }
    }

    public virtual void Collision(GameObject other)
    {
        if (other.CompareTag("Rock"))
        {

            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<Rock>().Hole = true;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.position = transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
            particule.SetActive(true);
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
            other.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
            audioSource.PlayOneShot(audioClip);
        }
    }

    protected virtual void Restart()
    {
        GetComponent<BoxCollider2D>().enabled = true;

        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        particule.SetActive(false);
    }
}
