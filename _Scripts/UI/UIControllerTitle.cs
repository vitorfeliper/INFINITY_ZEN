using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerTitle : MonoBehaviour
{
    public void play(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
