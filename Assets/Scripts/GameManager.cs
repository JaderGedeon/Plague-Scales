using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int m_currentLevelIndex = 0;
    [SerializeField] private GameObject m_currentLevel;
    [SerializeField] private List<GameObject> m_levels;
    private ResetCounter m_reset;

    public static GameManager Instance { get; private set; }

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GoToNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyAndLoadLevel();
            m_reset.IncrementCounter();
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

    private void DestroyAndLoadLevel()
    {
        Destroy(m_currentLevel);
        m_currentLevel = Instantiate(m_levels[m_currentLevelIndex]);
    }
}
