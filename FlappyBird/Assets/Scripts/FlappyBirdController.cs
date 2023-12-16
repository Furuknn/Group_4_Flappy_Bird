using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class FlappyBirdController : MonoBehaviour
{
    public float jumpForce = 5f;
    public Text score_text;
    public float score;
    public GameObject pipe;

    private void Start()
    {
        score = 0;
        GetComponent<Collider2D>().enabled = true;
        jumpForce = 5f;
        pipe.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }

        score_text.text = score.ToString();

        if (Time.timeScale >= 2f) 
        {
            float maxTime = 5f;
            float timer = 0f;
            timer = Time.deltaTime;
            if (timer >= maxTime) 
            {
                timer = 0f;
                Time.timeScale = 1f;
                jumpForce = 0f;
                pipe.SetActive(true);
                GetComponent<Collider2D>().enabled = true;
                GetComponent<Rigidbody2D>().gravityScale = 2;

            }
            
        }

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
            Time.timeScale = 2.0f;
            score = score + 5;
            jumpForce = 0f;
            pipe.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 0;
            GetComponent<Rigidbody2D>().gravityScale = 0; 
        }
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {
        if ( temas.gameObject.tag == "Pipe")
        {
           // Time.timeScale = 0;
        }
    }
}

