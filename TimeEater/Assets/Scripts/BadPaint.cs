using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPaint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerCheck"))
        {
            CountDown.timer -= 10;
        }
    }
}