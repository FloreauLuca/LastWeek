using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool dead = false;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float nbBullet;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBullet()
    {
        while (!dead)
        {
            bool circle = Random.value > 0;
            if (circle)
            {
                Vector3 targetPosition = GameManager.Instance.Player.transform.position;
                for (int i = 1; i <= nbBullet; i++)
                {
                   
                    Vector3 intialPosition = new Vector3(targetPosition.x + (Mathf.Cos(Mathf.PI * 2 / (nbBullet) * i) * 5), targetPosition.y + (Mathf.Sin(Mathf.PI * 2 / (nbBullet) * i) * 5), targetPosition.z);
                    GameObject bullet = Instantiate(bulletPrefab, intialPosition, Quaternion.identity, transform);
                    bullet.GetComponent<Bullet>().TargetPosition = targetPosition;
                }
            }
            else
            {
                
            }

            yield return new WaitForSeconds(5);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            Destroy(gameObject);
        }
    }
}
