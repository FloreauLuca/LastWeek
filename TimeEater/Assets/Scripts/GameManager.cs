using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Location
{
    ROOM0,
    ROOM1,
    ROOMGLACE1,
    ROOMGLACE2,
    ROOMBLOC1,
    ROOMBLOC2,
    ROOMBOSS
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public bool end;
    [SerializeField][Range(0, 5)] private int victim;
    public int Victim
    {
        get { return victim; }
        set { victim = value; }
    }
    
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

    [SerializeField] private bool playermode;

    public bool Playermode
    {
        get { return playermode; }
        set { playermode = value; }
    }

    private Boss boss;

    public Boss Boss
    {
        get { return boss; }
    }
    public bool bossMode;

    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip2;
    [SerializeField] private AudioClip audioClip1;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Quit();
        }
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

    private void Quit()
    {
#if UNITY_STANDALONE_WIN
        Application.Quit();
#endif
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
        audioSource = GetComponent<AudioSource>();
    }

    void SetupScene() // initialise le niveau
    {
        player = GameObject.FindObjectOfType<Player>();
        if (player)
        {
            if (playermode)
            {
                player.CasePercase = true;
            }
            else
            {
                player.CasePercase = false;
            }
            
        }
        boss = GameObject.FindObjectOfType<Boss>();
        if (boss)
        {
            boss.StartBoss = false;
            bossMode = false;
            audioSource.clip = audioClip1;
            audioSource.Play();
        }
        camera = GameObject.FindObjectOfType<CameraManager>();
        Time.timeScale = 1;
        end = false;
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        SceneManager.LoadScene("Lose");
        end = true;
    }

    public void Win()
    {
        //Time.timeScale = 0
        SceneManager.LoadScene("Win");
        end = true;
    }

    public void LaunchBoss()
    {
        boss.StartBoss = true;
        bossMode = true;
        audioSource.clip = audioClip2;
        audioSource.Play();
    }
    
}

