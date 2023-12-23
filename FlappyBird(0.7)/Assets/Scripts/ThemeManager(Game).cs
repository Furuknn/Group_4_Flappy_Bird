using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManagerGame : MonoBehaviour
{
    MainMenuScript menuScript;


    [SerializeField] private GameObject backgroungOrg, backgroundXmas;
    [SerializeField] private GameObject getReadyOrg, getReadyXmas;
    [SerializeField] private GameObject gameOverOrg, gameOverXmas;


    // Start is called before the first frame update
    void Start()
    {
        menuScript = FindObjectOfType<MainMenuScript>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerPrefs.GetString("currentTheme","")=="christmas")
        {
            backgroundXmas.SetActive(true);
            backgroungOrg.SetActive(false);
            getReadyXmas.SetActive(true);
            getReadyOrg.SetActive(false);
            gameOverXmas.SetActive(true);
            gameOverOrg.SetActive(false);

        }
        else if (PlayerPrefs.GetString("currentTheme", "") == "original")
        {
            backgroundXmas.SetActive(false);
            backgroungOrg.SetActive(true);
            getReadyXmas.SetActive(false);
            getReadyOrg.SetActive(true);
            gameOverXmas.SetActive(false);
            gameOverOrg.SetActive(true);


        }
    }
}
