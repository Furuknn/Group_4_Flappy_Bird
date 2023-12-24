using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{

    public AudioSource buttonClickSFX;
    public AudioSource playSFX;

    public void ButtonClickSFX()
    {
        buttonClickSFX.Play();
    }
    public void HitPlay()
    {
        playSFX.Play();
    }
}
 
