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
        // Game Over menüsünü baþlangýçta gizle
        gameOverMenu.SetActive(false);
        getReadyMenu.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        // Game Over menüsünü aktifleþtir
        gameOverMenu.SetActive(true);

    }

    public void HideGetReadyMenu()
    {
        getReadyMenu.SetActive(false);
    }

    public void RestartGame()
    {
        // Oyunu yeniden baþlat
        SceneManager.LoadScene("FlappyBird");

    }

    public void MainMenu()
    {
        // Ana Menüye dön
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