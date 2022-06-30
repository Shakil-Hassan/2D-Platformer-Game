
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    
    
    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    

    
}
