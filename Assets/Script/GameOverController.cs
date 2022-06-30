
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
   
    public bool gameHasEnded = false;
    public float restartDelay;

    

    public void EndGame()
    {
        
            Invoke("PlayerDied", restartDelay);
       
    }
    
   public void PlayerDied()
   {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
       gameObject.SetActive(true);
   }

   public void RestartLevel() //Restarts the level
   {
        SoundManager.Instance.PlayMusic(Sounds.Music);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

    public void returnMainMenu()
    {
        SoundManager.Instance.PlayMusic(Sounds.Music);
        SceneManager.LoadScene(0);
    }
    public void ExitLevel() //Restarts the level
   { 
       
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
   }



    // public GameObject otherGameObject;
 
    // public void Foo() {
    //     StartCoroutine(TemporarilyDeactivate(20));
    // }
 
    // private IEnumerator TemporarilyDeactivate(float duration) {
    //     otherGameObject.SetActive(false);
    //     yield return new WaitForSeconds(duration);
    //     otherGameObject.SetActive(true);
    // }
}
