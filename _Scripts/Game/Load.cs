using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public string cenaACarregar;
    public float tempoFixoSeg = 5;
    public enum TipoCarreg { Carregamento, TempoFixo }
    public TipoCarreg TipoDeCarregamento;
    public Image barraDeCarregamento;
    public Text TextoProgresso;
    //public int aux = 0;

    private int progresso = 0;
    private string textoOriginal;

    // Start is called before the first frame update
    void Start()
    {
        switch (TipoDeCarregamento)
        {
            case TipoCarreg.Carregamento:
                StartCoroutine(CenaDeCarregamento(cenaACarregar));
                Debug.Log("Carregado!!");
                break;

            case TipoCarreg.TempoFixo:
                StartCoroutine(TempoFixo(cenaACarregar));
                Debug.Log("Carregado!!");
                break;
        }

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

    IEnumerator CenaDeCarregamento(string cena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);

        while (!carregamento.isDone)
        {
            progresso = (int)(carregamento.progress * 100.0f);
            yield return null;
        }
    }

    IEnumerator TempoFixo(string cena)
    {
        yield return new WaitForSeconds(tempoFixoSeg);

        SceneManager.LoadScene(cena);
        Debug.Log("Carregado!!");

    }

    // Update is called once per frame
    void Update()
    {
        switch (TipoDeCarregamento)
        {
            case TipoCarreg.Carregamento:
                break;

            case TipoCarreg.TempoFixo:
                progresso = (int)(Mathf.Clamp((Time.time / tempoFixoSeg), 0.0f, 1.0f) * 100.0f);
                break;
        }
        if (TextoProgresso != null)
        {
            TextoProgresso.text = (textoOriginal + " " + progresso + "%");
        }
        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.fillAmount = (progresso / 100.0f);
        }
    }
}
