using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPhase : MonoBehaviour
{
    private const string k_Player = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(k_Player)) 
        {
            GameManager.Instance.GoToNextLevel();
            FindObjectOfType<AudioManager>().Play("Completed");
        }
    }
}
