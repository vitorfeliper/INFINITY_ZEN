using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound6 : MonoBehaviour
{
    public static Sound6 sound;

    private void Start()
    {
        sound = this;
    }
    void Awake()
    {
        if (sound == null)
        {
            sound = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
