using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenButtons : MonoBehaviour
{
    public AudioSource _audio;

    public void PlayAudio()
    {
        _audio.Play();
    }
}
