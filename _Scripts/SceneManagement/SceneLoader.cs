using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingOverlay;

    [Range(0.01f, 3f)]
    [SerializeField] private float fadeTime = 0.5f;

    public Image barraDeCarregamento;
    public Text TextoProgresso;
    //public int aux = 0;

    private int progresso = 0;
    private string textoOriginal;
    public static SceneLoader Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (TextoProgresso != null)
        {
            TextoProgresso.text = (textoOriginal + " " + progresso + "%");
        }
        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.fillAmount = (progresso / 100.0f);
        }
    }

    private void Start()
    {
        LoadSceneAsync("Menu");
        if (TextoProgresso != null)
        {
            textoOriginal = TextoProgresso.text;
        }
        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.type = Image.Type.Filled;
            barraDeCarregamento.fillMethod = Image.FillMethod.Horizontal;
            barraDeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
    }

    public void LoadScene()
    {
        LoadSceneAsync("Menu");
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(PerformLoadSceneAsync(sceneName));
    }

    private IEnumerator PerformLoadSceneAsync(string sceneName)
    {
        yield return StartCoroutine(FadeIn());

        var operation = SceneManager.LoadSceneAsync(sceneName);
        while(operation.isDone == false)
        {
            progresso = (int)(operation.progress * 100.0f);
            yield return null;
        }

        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;

        //DS/DT (start -> end)
        float speed = (end - start) / fadeTime;
        loadingOverlay.alpha = start;
        while(loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        loadingOverlay.alpha = end;
    }

    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;

        //DS/DT (start -> end)
        float speed = (end - start) / fadeTime;
        loadingOverlay.alpha = start;
        while (loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        loadingOverlay.alpha = end;
    }
}
