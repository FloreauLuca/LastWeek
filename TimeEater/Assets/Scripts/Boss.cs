using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool dead = false;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float nbBullet;
    [SerializeField] private float radius;
    [SerializeField] private float speed;

    [SerializeField] private Transform cameraTranslation;
    [SerializeField] private Transform playerTranslation;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());

        GameManager.Instance.Player.transform.position = playerTranslation.position;
        GameManager.Instance.Camera.transform.position = cameraTranslation.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBullet()
    {
        while (!dead)
        {

            yield return new WaitForSeconds(5);
            bool circle = Random.value > 0.5;
            if (circle)
            {
                Vector3 targetPosition = GameManager.Instance.Player.transform.position;
                for (int i = 1; i <= nbBullet; i++)
                {
                   
                    Vector3 intialPosition = new Vector3(targetPosition.x + (Mathf.Cos(Mathf.PI * 2 / (nbBullet) * i) * radius), targetPosition.y + (Mathf.Sin(Mathf.PI * 2 / (nbBullet) * i) * radius), targetPosition.z);
                    GameObject bullet = Instantiate(bulletPrefab, intialPosition, Quaternion.identity, transform);
                    bullet.GetComponent<Bullet>().TargetPosition = targetPosition;
                    bullet.GetComponent<Bullet>().Speed = speed;
                    bullet.GetComponent<Bullet>().Circle = true;
                }
            }
            else
            {
                Vector3 targetPosition = GameManager.Instance.Player.transform.position;
                for (int i = 1; i <= nbBullet*2; i++)
                {

                    Vector3 intialPosition = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
                    GameObject bullet = Instantiate(bulletPrefab, intialPosition, Quaternion.identity, transform);
                    bullet.GetComponent<Bullet>().TargetPosition = targetPosition;
                    bullet.GetComponent<Bullet>().Circle = false;
                    bullet.GetComponent<Bullet>().Speed = speed;
                    yield return new WaitForSeconds(0.1f);
                }
            }

        }
    }
}
