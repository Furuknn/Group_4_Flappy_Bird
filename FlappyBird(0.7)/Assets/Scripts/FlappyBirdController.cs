using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class FlappyBirdController : MonoBehaviour
{
    float shieldDuration = 7.0f;
    float multiplierDuration = 7.0f;

    public float jumpForce = 5f;
    private float rotationSpeed = 5f;

    public Text score_text;
    public TextMeshProUGUI creditsData;
    public int score;

    private Rigidbody2D rigidBody2D;
    public GameObject pipes,pipeUp,pipeDown;
    public GameObject shieldItem,multiplierItem;
    [SerializeField] private GameObject forceField;
    [SerializeField] private GameObject multSprite;
    [SerializeField] private GameObject glowParticles; 
    [SerializeField] private Animator animator;
    [HideInInspector] public bool inShield = false;
    [HideInInspector] public bool isSpeedy = false;
    [HideInInspector] public bool isFailed = false;
    [HideInInspector] public bool isMultiplierOn = false;

    private void Start(){
        PlayerPrefs.SetInt("Total_Credits", 0);

        Time.timeScale = 0f;
        score = 0;
        rigidBody2D = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = true;
        jumpForce = 5f;
        inShield = false;

        pipes.SetActive(true);
        forceField.SetActive(false);
        shieldItem.SetActive(true);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isSpeedy==false && isFailed==false)
            {
                Time.timeScale = 1f;
                FindObjectOfType<GameManager>().HideGetReadyMenu();
            }
            if (transform.position.y >= 4.0) { }
            else
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }

        if (isFailed == true && Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("FlappyBird");
        }

        score_text.text = score.ToString();
        creditsData.text = PlayerPrefs.GetInt("Total_Score", 0).ToString();

    }
    private void LateUpdate(){
        if (isMultiplierOn == true){
            multSprite.SetActive(true);
            score_text.color = Color.yellow;
        }
        else{
            multSprite.SetActive(false);
            score_text.color= Color.white;
        }
        if (isFailed==true){
            GameOver();
        } 
    }
    private void FixedUpdate(){
        transform.rotation = Quaternion.Euler(0, 0, rigidBody2D.velocity.y * rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Scorer")
        {
            if (isMultiplierOn == true)
            {
                score += 2;
                Invoke("DeactivateMultiplier", multiplierDuration);
            }
            else
                ++score;
        }

        if (temas.gameObject.tag == "Speed")
        {
            Destroy(temas.gameObject);
            Time.timeScale = 4f;
            jumpForce = 0f;
            isSpeedy = true;
            glowParticles.SetActive(true);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 0;
            GetComponent<Rigidbody2D>().gravityScale = 0;

            StartCoroutine(ResetSpeedBoost()); //ResetSpeedBoost fonksiyonunu çalýþtýrýr.
        }

        if (temas.gameObject.tag == "Shield")
        {
            Destroy(temas.gameObject);
            forceField.SetActive(true);
            inShield = true;

            Invoke("BreakShield", shieldDuration * Time.timeScale);
        }
        if (temas.gameObject.tag == "Multiplier")
        {
            Destroy(temas.gameObject);
            isMultiplierOn = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Pipe")
        {
            if (inShield)
            {
                temas.collider.enabled = false; //shield aktifken temas edilen pipe'ýn collider'ýný kapatýr.
                Invoke("BreakShield", 0);
            }
            else
            {
                isFailed = true;
                PlayerPrefs.SetInt("Total_Score", PlayerPrefs.GetInt("Total_Score", 0) + score);
                PlayerPrefs.Save();
                Time.timeScale = 0;

            }
        }
        else if (temas.gameObject.tag == "Ground")
        {
            if (inShield)
            {
                Invoke("BreakShield", 0);
            }
            else
            {
                isFailed = true;
                PlayerPrefs.SetInt("Total_Score", PlayerPrefs.GetInt("Total_Score", 0) + score); //PlayerPrefs küçük boyutlu veri saklar. Oyun kapatýldýðýnda bile veri kaybedilmez. 
                PlayerPrefs.Save();
                Time.timeScale = 0;
            }
        }
    }    

    private IEnumerator ResetSpeedBoost() //hýz boostu bittikten sonra her þeyi normale döndürür.
    {
        yield return new WaitForSeconds(7.0f*Time.timeScale); //hýz boostunun 7 saniye sürmesini saðlar.

        jumpForce = 5f;
        Time.timeScale = 1.0f;
        GetComponent<Rigidbody2D>().gravityScale = 2.0f;

        yield return new WaitForSeconds(1.0f); //hýz boostu bittikten sonra oyuncunun kendini toparlamasý için süre verilir.
        
        isSpeedy = false;
        glowParticles.SetActive(false);
    }

    private void BreakShield()
    {
        animator.SetBool("IsShieldBroken", true);

        Invoke("TurnOffShield", 0.8f);
    }
    private void TurnOffShield() {
        animator.SetBool("IsShieldBroken", false);
        forceField.SetActive(false);
        inShield = false;
    }
    private void DeactivateMultiplier() {
        isMultiplierOn = false;
        
    }
    void GameOver()
    {
        // Game Over menüsünü etkinleþtir
        FindObjectOfType<GameManager>().ShowGameOverMenu();
        score_text.transform.position = Vector3.zero;
        score_text.color = Color.white;
        multSprite.SetActive(false);
        Time.timeScale = 0;


    }
}

