using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        // Garantir que s� exista uma inst�ncia do UIManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    // Refer�ncia para os bot�es de cor e texto de UI
    [SerializeField] Button[] botoes;
    [SerializeField] TextMeshProUGUI sequenciaTexto, errouTexto, acertouTexto;

    private void Start()
    {
        // Configura os bot�es para que ao serem clicados chamem o m�todo ChecarCor
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i;  // Captura o �ndice de cada bot�o
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x));
        }
    }

    // M�todo para atualizar os acertos na UI
    public void AtualizarAcertos(int acertos)
    {
        acertouTexto.text = acertos.ToString();
    }

    // M�todo para atualizar os erros na UI
    public void AtualizarErros(int erros)
    {
        errouTexto.text = erros.ToString();
    }

    // M�todo para limpar o texto da sequ�ncia de cores na UI
    public void LimparTexto()
    {
        sequenciaTexto.text = "";
    }

    // M�todo para atualizar a sequ�ncia de cores na UI
    public void AtualizarSequencia(string nomeDaCor)
    {
        sequenciaTexto.text += nomeDaCor + " ";  // Adiciona cada nome de cor � sequ�ncia
    }
}

