using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    
    public AudioSource shieldOnSFX;
    public AudioSource shieldOffSFX;
    public AudioSource wingSFX;
    public AudioSource deathSFX;
    public AudioSource buttonClickSFX;

    public void ButtonClickSFX()
    {
        buttonClickSFX.Play();
    }
}
