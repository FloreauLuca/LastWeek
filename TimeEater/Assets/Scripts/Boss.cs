using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private int bossState = 0;

    public int BossState
    {
        get { return bossState; }
        set
        {
            bossState = value;

            puzzleTileMap[bossState-1].SetActive(false);
            puzzleTileMap[bossState].SetActive(true);
            GameManager.Instance.Player.StartPosition = GameManager.Instance.Player.transform.position;
        }
    }

    private bool dead = false;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float nbBullet;
    [SerializeField] private float radius;
    [SerializeField] private float speed;

    [SerializeField] private Transform cameraTranslation;
    [SerializeField] private Transform playerTranslation;

    [SerializeField] private Incantation[] incantations;
    [SerializeField] private Torture[] prisoniers;
    [SerializeField] private GameObject[] prisoniersImage;
    [SerializeField] private GameObject[] puzzleTileMap;
    [SerializeField] private Door door;

    private bool startBoss = false;

    public bool StartBoss
    {
        get { return startBoss; }
        set
        {
            startBoss = value;
            if (startBoss)
            {

                //StartCoroutine(SpawnBullet());
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (door.Closed && VictimeTest())
        {
            door.Closed = false;
        }

        if (IncantationTest())
        {
            dead = true;
            GameManager.Instance.Win();
        }
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

    public bool IncantationTest()
    {

        foreach (var incantation in incantations)
        {
            if (!incantation.Filled)
            {
                return false;
            }
        }

        return true;

    }
    public bool VictimeTest()
    {
        foreach (var prisonier in prisoniers)
        {
            if (!prisonier.Tortured)
            {
                return false;
            }
        }
        return true;
    }

    public void VictimeKill()
    {
        for (int i = 0; i < prisoniers.Length; i++)
        {
            prisoniersImage[i].GetComponent<Image>().enabled = !prisoniers[i].Tortured;
        }
    }
    
}
