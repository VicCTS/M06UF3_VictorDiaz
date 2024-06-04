using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip bgmAudio;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartBGM();
    }

    void StartBGM()
    {
        audioSource.clip = bgmAudio;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    void PauseBGM()
    {
        audioSource.Pause();
    }
}
