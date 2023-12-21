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
        // Game Over men�s�n� ba�lang��ta gizle
        gameOverMenu.SetActive(false);
        Score.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        // Game Over men�s�n� aktifle�tir
        gameOverMenu.SetActive(true);
        //Score.SetActive(false);

    }

    public void RestartGame()
    {
        // Oyunu yeniden ba�lat
        SceneManager.LoadScene("FlappyBird");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}