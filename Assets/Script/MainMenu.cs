
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        LevelSelection.SetActive(true);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit successfully");
        Application.Quit();
    }
}
