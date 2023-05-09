using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSet : MonoBehaviour
{
    public AudioSource clear;
    public AudioSource snow;
    public AudioSource rain;

    public void ClearWT()
    {
        
        clear.Play();
        snow.Stop();
        rain.Stop();
    }

    public void SnowWT()
    {
        clear.Stop();
        snow.Play();
        rain.Stop();
    }

    public void RainWT()
    {
        clear.Play();
        snow.Stop();
        rain.Play();
    }
}
