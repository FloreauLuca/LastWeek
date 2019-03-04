using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torture : MonoBehaviour
{
    [SerializeField] public Location myLocation;

    [SerializeField] private Sprite killSprite;
    [SerializeField] private GameObject blood;
    [SerializeField] private SpriteRenderer spriteRenderer;

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
            //Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.sprite = killSprite;
        spriteRenderer.color = new Color(255, 50, 50);
        blood.SetActive(true);

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
