using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsMusicController : MonoBehaviour
{
    [SerializeField] private int IdleMusic;
    [SerializeField] private int RockMusic;
    [SerializeField] private int EletronicMusic;
    [SerializeField] private int ReggaeMusic;
    [SerializeField] private int RapMusic;

    public void ActiveIdleMusic()
    {
        MusicPlayer.Instance.currentMusic = 0;
        MusicPlayer.Instance.StartAudio(IdleMusic);
    }

    public void ActiveRockMusic()
    {
        MusicPlayer.Instance.currentMusic = 0;
        MusicPlayer.Instance.StartAudio(RockMusic);
    }

    public void ActiveEletronicMusic()
    {
        MusicPlayer.Instance.currentMusic = 0;
        MusicPlayer.Instance.StartAudio(EletronicMusic);
    }

    public void ActiveReggaeMusic()
    {
        MusicPlayer.Instance.currentMusic = 0;
        MusicPlayer.Instance.StartAudio(ReggaeMusic);
    }

    public void ActiveRapMusic()
    {
        MusicPlayer.Instance.currentMusic = 0;
        MusicPlayer.Instance.StartAudio(RapMusic);
    }
}
