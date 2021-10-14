using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound sound;

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
