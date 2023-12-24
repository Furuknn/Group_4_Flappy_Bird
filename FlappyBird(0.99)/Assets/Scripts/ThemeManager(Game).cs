using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManagerGame : MonoBehaviour
{
    MainMenuScript menuScript;


    [SerializeField] private GameObject backgroungOrg, backgroundXmas;
    [SerializeField] private GameObject bgMusicOrg, bgMusicXmas;
    [SerializeField] private GameObject getReadyOrg, getReadyXmas;
    [SerializeField] private GameObject gameOverOrg, gameOverXmas;
    [SerializeField] private GameObject birdOrg, birdXmas;
    [SerializeField] private GameObject groundOrg, groundXmas;


    // Start is called before the first frame update
    void Start()
    {
        menuScript = FindObjectOfType<MainMenuScript>();

        if (PlayerPrefs.GetString("currentTheme", "") == "christmas")
        {
            backgroundXmas.SetActive(true);
            backgroungOrg.SetActive(false);
            getReadyXmas.SetActive(true);
            getReadyOrg.SetActive(false);
            gameOverXmas.SetActive(true);
            gameOverOrg.SetActive(false);
            bgMusicXmas.SetActive(true);
            bgMusicOrg.SetActive(false);
            birdXmas.SetActive(true);
            birdOrg.SetActive(false);
            groundXmas.SetActive(true);
            groundOrg.SetActive(false);

        }
        else if (PlayerPrefs.GetString("currentTheme", "") == "original")
        {
            backgroundXmas.SetActive(false);
            backgroungOrg.SetActive(true);
            getReadyXmas.SetActive(false);
            getReadyOrg.SetActive(true);
            gameOverXmas.SetActive(false);
            gameOverOrg.SetActive(true);
            bgMusicXmas.SetActive(false);
            bgMusicOrg.SetActive(true);
            birdXmas.SetActive(false);
            birdOrg.SetActive(true);
            groundXmas.SetActive(false);
            groundOrg.SetActive(true);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
