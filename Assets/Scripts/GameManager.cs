using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private Button m_continueButton;
    [SerializeField] private GameObject m_pauseButton;
    [SerializeField] private int m_currentLevelIndex = 0;
    [SerializeField] private GameObject m_currentLevel;
    [SerializeField] private List<GameObject> m_levels;
    private float m_timer = 0f;


    public static GameManager Instance { get; private set; }
    public static bool IsPaused { get; private set; }
    public int counter { get; set; }
    public ResetCounter m_reset;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_currentLevel = Instantiate(m_levels[m_currentLevelIndex]);
        //m_reset = FindObjectOfType<ResetCounter>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    GoToNextLevel();
        //}

        if (Input.GetKey(KeyCode.R))
        {
            m_timer += 1.5f * Time.deltaTime;
            if (m_timer > 3)
            {
                m_timer = 0f;
                FindObjectOfType<AudioManager>().Play("Restart");
                DestroyAndLoadLevel();
                m_reset.IncrementCounter();
            }
        }
        if(!Input.GetKey(KeyCode.R))
            m_timer = 0f;

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (IsPaused)
            {
                ResumeInGameMenu();
            }
            else 
            {
                PauseInGameMenu();
            }
        }
    }

    public void GoToNextLevel()
    {
        if (m_levels.Count <= m_currentLevelIndex + 1)
        {
            Debug.Log("Jogador atingiu o nível máximo");
            return;
        }

        m_currentLevelIndex++;
        DestroyAndLoadLevel();
    }

    public void DestroyAndLoadLevel()
    {
        Destroy(m_currentLevel);
        m_currentLevel = Instantiate(m_levels[m_currentLevelIndex]);
    }

    public void PauseInGameMenu() 
    {
        m_pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        FindObjectOfType<AudioManager>().inPause = true;
        FindObjectOfType<AudioManager>().Pause();
    }

    public void ResumeInGameMenu() 
    {
        m_pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        FindObjectOfType<AudioManager>().inPause = false;
        FindObjectOfType<AudioManager>().UnPause();
    }

    public void GoToMenuInPause() 
    {
        Time.timeScale = 0f;
        m_mainMenu.SetActive(true);
        m_pauseMenu.SetActive(false);
        m_pauseButton.SetActive(false);
    }
    public void QuitInMenuGame() 
    {
        Application.Quit();
    }

    public void NewGame()
    {
        if (m_currentLevelIndex != 0)
        {
            m_currentLevelIndex = 0;            
        }
        DestroyAndLoadLevel();
        Time.timeScale = 1f;
        IsPaused = false;
        m_continueButton.interactable = true;
        m_mainMenu.SetActive(false);
        m_pauseButton.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Ambience");
    }

    /*public void Continue()
    {
        DestroyAndLoadLevel();
        Time.timeScale = 1f;
        IsPaused = false;
        m_mainMenu.SetActive(false);
        m_pauseButton.SetActive(true);
    }*/
}
