using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
    {

        public void LoadMenu()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Menu");
        }
        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
}
