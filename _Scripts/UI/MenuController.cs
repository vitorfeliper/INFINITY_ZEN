using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    [SerializeField] private GameObject Open_Buton = null;
    [SerializeField] private GameObject Close_Buton = null;
    [SerializeField] private GameObject Music_Panel = null;
    [SerializeField] Animator _ac = null;
    //[SerializeField] private RectTransform rectTransform = null;

    private void Start()
    {
        Instance = this;
        _ac = GetComponentInChildren<Animator>();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AnimIN()
    {
        _ac.Play("MusicPanel_IN");
        Close_Buton.SetActive(true);
        Open_Buton.SetActive(false);
        Music_Panel.SetActive(true);
    }

    public void AnimOut()
    {
        _ac.Play("MusicPanel_OUT");
        Close_Buton.SetActive(false);
        Open_Buton.SetActive(true);
        Music_Panel.SetActive(false);
    }
}
