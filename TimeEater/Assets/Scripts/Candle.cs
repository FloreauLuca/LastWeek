using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro.EditorUtilities;
using UnityEditorInternal;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] private GameObject cadleOn;
    [SerializeField] private GameObject candleOff;
    public bool candleActivated = true;

    public void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (candleActivated)
                {
                    case true:
                        gameObject.GetComponent<SpriteRenderer>().enabled = true;
                        candleActivated = false;
                        break;
                    
                    case false:
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        candleActivated = true;
                        break;
                }
            }
        }
    }
}
