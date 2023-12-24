using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    public GameObject pipeUp;
    public GameObject pipeDown;
    private FlappyBirdController flappyBirdControllerscr;
    
    // Start is called before the first frame update
    void Start()
    {
        flappyBirdControllerscr = FindObjectOfType<FlappyBirdController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flappyBirdControllerscr.isSpeedy==true)
        {
            pipeUp.GetComponent<BoxCollider2D>().enabled = false;
            pipeDown.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (flappyBirdControllerscr.isSpeedy == false)
        {
            if (flappyBirdControllerscr.inShield==true)
            {
                
            }
            else if (flappyBirdControllerscr.inShield==false)
            {
                pipeUp.GetComponent<BoxCollider2D>().enabled = true;
                pipeDown.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
