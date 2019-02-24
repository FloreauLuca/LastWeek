using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCheck"))
        {
            if (!other.GetComponent<Player>().CasePercase)
            {
                other.GetComponent<Player>().Iced = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCheck"))
        {
            if (!other.GetComponent<Player>().CasePercase)
            {
                other.GetComponent<Player>().Iced = false;
            }
        }
    }
}
