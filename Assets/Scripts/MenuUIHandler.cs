using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public Canvas levelSelectCanvas;
   public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LevelSelectCanvas()
    {
        gameObject.SetActive(false);
        levelSelectCanvas.gameObject.SetActive(true);
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void BackButtonPressed()
    {
        gameObject.SetActive(true);
        levelSelectCanvas.gameObject.SetActive(false);
    }
}
