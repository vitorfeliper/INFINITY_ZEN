using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    public int currentMusic = 0;
    public AudioSource audioSource;
    private bool stop = false;

    public AudioClip[] clipNames;
    public Text musicName;
    public Slider musicLength;

    public void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        StartAudio();
    }

    public void Update()
    {
        if (!stop)
        {
            musicLength.value += Time.deltaTime;
            if (musicLength.value >= audioSource.clip.length)
            {
                currentMusic++;
                if (currentMusic >= clipNames.Length)
                {
                    currentMusic = 0;
                }

                StartAudio();
            }
        }
    }

    public void StartAudio(int changeMusic = 0)
    {
        currentMusic += changeMusic;
        if(currentMusic >= clipNames.Length)
        {
            currentMusic = 0;
        }
        else if(currentMusic < 0)
        {
            currentMusic = clipNames.Length - 1;
        }

        if(audioSource.isPlaying && changeMusic == 0)
        {
            currentMusic = 0;
        }
        if (stop)
        {
            stop = false;
        }

        audioSource.clip = clipNames[currentMusic];
        musicName.text = audioSource.clip.name;
        musicLength.maxValue = audioSource.clip.length;
        musicLength.value = 0;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
        stop = true;
    }
}
