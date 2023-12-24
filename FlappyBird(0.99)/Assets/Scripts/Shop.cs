using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI credits_DATA;
    [SerializeField] private Text speedlevel_DATA,speedButtonTxt;
    [SerializeField] private Text shieldlevel_DATA, shieldButtonTxt;
    [SerializeField] private Text multiplierlevel_DATA, multiplierButtonTxt;
    [SerializeField] private TextMeshProUGUI purchase_Text;
    
   
    void Start()
    {
        // Eðer boost ücretleri halihazýrda kayýtlý deðilse 150 olarak kaydet
        if (!PlayerPrefs.HasKey("speedCost"))
        {
            PlayerPrefs.SetInt("speedCost", 150);
        }
        if (!PlayerPrefs.HasKey("multiplierCost"))
        {
            PlayerPrefs.SetInt("multiplierCost", 150);
        }
        if (!PlayerPrefs.HasKey("shieldCost"))
        {
            PlayerPrefs.SetInt("shieldCost", 150);
        }
        
        Debug.Log(PlayerPrefs.GetInt("speedCost"));
        
        
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetInt("speedLevel") == 3) 
        {
            PlayerPrefs.SetInt("speedCost", 0);
        }
        if (PlayerPrefs.GetInt("shieldLevel") == 3)
        {
            PlayerPrefs.SetInt("shieldCost", 0);
        }
        if (PlayerPrefs.GetInt("multiplierLevel") == 3)
        {
            PlayerPrefs.SetInt("multiplierCost", 0);
        }
        RefreshUI();
    }

    public void PurchaseSpeed()
    {
        PurchaseUpgrade("speed", "speedLevel", "speedCost");
    }
    public void PurchaseShield()
    {
        PurchaseUpgrade("shield", "shieldLevel", "shieldCost");
    }
    public void PurchaseMultiplier()
    {
        PurchaseUpgrade("multiplier", "multiplierLevel", "multiplierCost");
    }

    private void PurchaseUpgrade(string upgradeType, string levelKey, string costKey)
    {
        int currentLevel = PlayerPrefs.GetInt(levelKey);
        int currentCost = PlayerPrefs.GetInt(costKey);

        if (PlayerPrefs.GetInt("Total_Score") >= currentCost)
        {
            
            if (currentLevel < 3)
            {
                PlayerPrefs.SetInt("Total_Score", PlayerPrefs.GetInt("Total_Score") - currentCost);

                // O anki boost seviyesine göre fiyatý artýrýr
                currentCost = (currentLevel + 2) * 150;
                PlayerPrefs.SetInt(costKey, currentCost);
                PlayerPrefs.SetInt(levelKey, currentLevel + 1);

                purchase_Text.text = "PURCHASE SUCCESSFUL";
                purchase_Text.color = Color.green;
            }
            else
            {
                purchase_Text.text = "MAX LEVEL REACHED";
                PlayerPrefs.SetInt("speedCost", 0);
                purchase_Text.color = Color.red;
            }

        }
        else
        {
            purchase_Text.text = "NOT ENOUGH CREDITS";
            purchase_Text.color = Color.red;
        }

        Invoke("RefreshText", 3f);
    }


    public void RefreshText()
    {
        purchase_Text.text = "";
    }

    private void RefreshUI()
    {
        credits_DATA.text = PlayerPrefs.GetInt("Total_Score").ToString();
        speedlevel_DATA.text = PlayerPrefs.GetInt("speedLevel").ToString();
        multiplierlevel_DATA.text = PlayerPrefs.GetInt("multiplierLevel").ToString();
        shieldlevel_DATA.text = PlayerPrefs.GetInt("shieldLevel").ToString();
        speedButtonTxt.text = PlayerPrefs.GetInt("speedCost").ToString() + "C";
        multiplierButtonTxt.text = PlayerPrefs.GetInt("multiplierCost").ToString() + "C";
        shieldButtonTxt.text = PlayerPrefs.GetInt("shieldCost").ToString() + "C";
    }

}
