using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{

    public GameObject christmasButton, originalButton;
    public GameObject mainMenu_UI;
    public GameObject SettingsMenu;
    public GameObject ShopMenu;
 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void GoToScene()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void Quit()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ToggleSettings()
    {
        if (SettingsMenu.activeSelf == true)
        {
            SettingsMenu.SetActive(false);
            mainMenu_UI.SetActive(true);

        }
        else
        {
            SettingsMenu.SetActive(true);
            mainMenu_UI.SetActive(false);
        }

    }

    public void ToggleShop()
    {
        if (ShopMenu.activeSelf == true)
        {
            ShopMenu.SetActive(false);
            mainMenu_UI.SetActive(true);

        }
        else
        {
            ShopMenu.SetActive(true);
            mainMenu_UI.SetActive(false);
        }

    }

    public void ThemeChanger()
    {
        if (christmasButton.activeSelf)
        {
            christmasButton.SetActive(false);
            originalButton.SetActive(true);
           
            PlayerPrefs.SetString("currentTheme", "original");
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString("currentTheme", ""));
        }
        else
        {
            christmasButton.SetActive(true);
            originalButton.SetActive(false);
            
            PlayerPrefs.SetString("currentTheme", "christmas");
            PlayerPrefs.Save();

            Debug.Log(PlayerPrefs.GetString("currentTheme", ""));
        }
    }
}
