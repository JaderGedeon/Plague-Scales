using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPhase : MonoBehaviour
{
    public string phaseName;

    private void OnTriggerEnter(Collider other)
    {
        if (phaseName == null)
            return;

        if (other.gameObject.tag == "Player") 
        {
            SceneManager.LoadScene(phaseName);
            print("Next fase!");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void resetTheGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
}
