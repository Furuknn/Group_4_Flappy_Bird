using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public GameObject gameOverMenu;
    public GameObject getReadyMenu;
    public GameObject Score;
    

    void Start()
    {
        // Game Over men�s�n� ba�lang��ta gizle
        gameOverMenu.SetActive(false);
        getReadyMenu.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        // Game Over men�s�n� aktifle�tir
        gameOverMenu.SetActive(true);

    }

    public void HideGetReadyMenu()
    {
        getReadyMenu.SetActive(false);
    }

    public void RestartGame()
    {
        // Oyunu yeniden ba�lat
        SceneManager.LoadScene("FlappyBird");

    }

    public void MainMenu()
    {
        // Ana Men�ye d�n
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Pause();
    }

}