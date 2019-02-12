using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public bool end;
    
    private Player player;  // permet d'avoir accès au player de n'importe où

    public Player Player
    {
        get { return player; }
    }
    

    private CameraManager camera;

    public CameraManager Camera
    {
        get { return camera; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoadingScene;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoadingScene;
    }

    //this function is activated every time a scene is loaded
    private void OnLevelFinishedLoadingScene(Scene scene, LoadSceneMode mode)
    {
        SetupScene();
        Debug.Log("Scene Loaded");
    }


    void Start()
    {
        SetupScene();
    }

    void SetupScene() // initialise le niveau
    {
        player = GameObject.FindObjectOfType<Player>();
        camera = GameObject.FindObjectOfType<CameraManager>();
        Time.timeScale = 1;
        end = false;
    }

    public void End()
    {
        Time.timeScale = 0;
        end = true;
    }

    private void Update()
    {
        if (Input.GetButton("Restart"))
        {
            SceneManager.LoadScene("Luca");
        }
    }
}

