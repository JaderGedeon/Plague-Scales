using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetCounter : MonoBehaviour
{
    public TextMeshPro counterText;
    [SerializeField] private int m_counter = 0;

    public int IncrementCounter() { return m_counter += 1; }

    void Update()
    {
        ShowCounterInScene();
    }

    private void ShowCounterInScene()
    {
        counterText.text = string.Format("Resets + {0}", m_counter);
    }
}
