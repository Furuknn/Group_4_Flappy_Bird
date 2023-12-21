using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject Score;
    public FlappyBirdController Bird;

    void Start()
    {
        // Game Over menüsünü baþlangýçta gizle
        gameOverMenu.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        // Game Over menüsünü aktifleþtir
        gameOverMenu.SetActive(true);

    }

    public void RestartGame()
    {
        // Oyunu yeniden baþlat
        SceneManager.LoadScene("FlappyBird");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}