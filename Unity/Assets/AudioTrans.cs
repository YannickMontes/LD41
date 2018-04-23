using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]


public class AudioTrans : MonoBehaviour
{
    public AudioSource introductionSource;

    public AudioSource audioSource;

    void Start()
    {

        introductionSource.Play();

        Invoke("playLoop", 30);
    }

    private void playLoop()
    {
        audioSource.Play();
   
    }
}