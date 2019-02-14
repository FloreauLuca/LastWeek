using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private float mainTimer;

    public static float timer;

    void Start()
    {
        timer = mainTimer;
        uiText = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            uiText.text = "Timer : " + timer.ToString();

        }
        else if (timer <= 0.0f)
        {
            uiText.text = "Timer : " + timer;
            timer = 0.0f;
        }

        if (timer <= 0.0f)
        {
            //SceneManager.LoadScene("Lose");
        }
    }
}
