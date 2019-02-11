using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*
    [SerializeField] GameObject camera;
    [SerializeField] private GameObject player;
    */

    [SerializeField] private Vector3 cameraTranslation = new Vector3(10, 0, -10);
    [SerializeField] private Vector3 playerTranslation = new Vector3(3, 0, 0);



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCheck")
        {
            if (!GameManager.Instance.Player.mapMoving)
            {
                MoveRight();
                CountDown.timer += 10;
            }
        }
    }
 
    private void MoveRight()
    {
       GameManager.Instance.Player.transform.position = GameManager.Instance.Player.transform.position + playerTranslation;
       GameManager.Instance.Camera.transform.position = GameManager.Instance.Camera.transform.position + cameraTranslation;

    }
}
