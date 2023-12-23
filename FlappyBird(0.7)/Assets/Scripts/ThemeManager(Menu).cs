using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManagerMenu : MonoBehaviour
{
    MainMenuScript menuScript;

    public GameObject christmasButton, originalButton;
    [SerializeField]private GameObject backgroungOrg, backgroundXmas;
    [SerializeField]private GameObject signOrg, signXmas;

    // Start is called before the first frame update
    void Start()
    {
        menuScript = FindObjectOfType<MainMenuScript>();
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerPrefs.GetString("currentTheme", "") == "christmas")
        {
            backgroundXmas.SetActive(true);
            backgroungOrg.SetActive(false);
            signXmas.SetActive(true);
            signOrg.SetActive(false);
            christmasButton.SetActive(true);
            originalButton.SetActive(false);
        }
        else if (PlayerPrefs.GetString("currentTheme", "") == "original")
        {
            backgroundXmas.SetActive(false);
            backgroungOrg.SetActive(true);
            signXmas.SetActive(false);
            signOrg.SetActive(true);
            christmasButton.SetActive(false);
            originalButton.SetActive(true);

        }
    }
}
