using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*
    [SerializeField] GameObject camera;
    [SerializeField] private GameObject player;
    */

    [SerializeField] private Transform cameraTranslation;
    [SerializeField] private Transform playerTranslation;



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck")
        {
            if (!GameManager.Instance.Player.mapMoving)
            {
                MoveRight();
                //CountDown.timer += 10;
            }
        }
    }
 
    private void MoveRight()
    {
       GameManager.Instance.Player.transform.position = playerTranslation.position;
       GameManager.Instance.Camera.transform.position = cameraTranslation.position;

    }
}
