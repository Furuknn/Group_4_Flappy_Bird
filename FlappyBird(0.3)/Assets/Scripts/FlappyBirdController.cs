using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class FlappyBirdController : MonoBehaviour
{
    float shieldDuration = 0.8f;

    public float jumpForce = 5f;
    public Text score_text;
    public float score;
    public GameObject pipe;
    public GameObject shieldItem;
    [SerializeField] private GameObject forceField;
    [SerializeField]private Animator animator;
    public bool inShield = false;

    private void Start()
    {
        
        score = 0;
        GetComponent<Collider2D>().enabled = true;
        jumpForce = 5f;
        inShield = false;

        pipe.SetActive(true);
        forceField.SetActive(false);
        shieldItem.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }

        score_text.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Scorer")
        {
            score++;
        }

        if(temas.gameObject.tag == "Speed")
        {
            Destroy(temas.gameObject);
            Time.timeScale = 6.5f;
            score += 10;
            jumpForce = 0f;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 0;
            GetComponent<Rigidbody2D>().gravityScale = 0; 

            StartCoroutine(ResetSpeedBoost()); //ResetSpeedBoost fonksiyonunu çalýþtýrýr.
        }

        if(temas.gameObject.tag == "Shield")
        {
            Destroy (temas.gameObject);
            forceField.SetActive(true);
            inShield = true;

            Invoke("EndShieldSkill", 5.0f);
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
            else{
                Time.timeScale = 0;
            }
        }
        else if (temas.gameObject.tag=="Ground")
        {
            if (inShield)
            {
                Invoke("BreakShield", 0);
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

    private IEnumerator ResetSpeedBoost() //hýz boostu bittikten sonra her þeyi normale döndürür.
    {
        yield return new WaitForSeconds(8.0f); //hýz boostunun 4-5 saniye sürmesini saðlar.

        jumpForce = 5f;
        Time.timeScale = 1.0f;
        GetComponent<Rigidbody2D>().gravityScale = 2.0f;

        yield return new WaitForSeconds(1.5f); //hýz boostu bittikten sonra oyuncunun kendini toparlamasý için süre verilir.
        GetComponent<Collider2D>().enabled = true;
    }

    private void EndShieldSkill()
    {
        Invoke("BreakShield",0);
    }
    private void BreakShield()
    {
        animator.SetBool("IsShieldBroken", true);

        Invoke("TurnOffShield", shieldDuration);
    }
    private void TurnOffShield() {
        animator.SetBool("IsShieldBroken", false);
        forceField.SetActive(false);
        inShield = false;
    }
}

