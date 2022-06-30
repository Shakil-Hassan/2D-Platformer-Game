using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    //GameManager gm;

    private int nextLevel;
    

    public GameObject levelComplete;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            
            Debug.Log("Level Completed");
            LevelManager.Instance.MarkCurrentLevelComplete();
            levelComplete.SetActive(true);
        }
    }

    public void PlayNext()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void QuitGame()
    {
        Debug.Log("Game Quit successfully");
        Application.Quit();
    }

}
