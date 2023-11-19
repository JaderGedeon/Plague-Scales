using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        ShowCounterInScene();
    }

    public int IncrementCounter() { return gameManager.counter += 1; }

    private void ShowCounterInScene()
    {
        counterText.text = string.Format("Reset: {0}", gameManager.counter);
    }
}