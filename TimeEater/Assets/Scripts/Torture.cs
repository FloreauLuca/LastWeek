using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torture : MonoBehaviour
{
    [SerializeField] public Location myLocation;

    private bool tortured = false;

    public bool Tortured
    {
        get { return tortured; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Restart") && GameManager.Instance.Player.PlayerLocation == myLocation)
        {
            Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        if (!tortured)
        {
            tortured = true;
            GameManager.Instance.Victim++;
        }
        GameManager.Instance.Boss.VictimeKill();
    }

    void Restart()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        if (tortured)
        {
            tortured = false;
            GameManager.Instance.Victim--;
        }
        GameManager.Instance.Boss.VictimeKill();
    }
}
