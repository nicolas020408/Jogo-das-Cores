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
        // Garantir que só exista uma instância do UIManager
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

    // Referência para os botões de cor e texto de UI
    [SerializeField] Button[] botoes;
    [SerializeField] TextMeshProUGUI sequenciaTexto, errouTexto, acertouTexto;

    private void Start()
    {
        // Configura os botões para que ao serem clicados chamem o método ChecarCor
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i;  // Captura o índice de cada botão
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x));
        }
    }

    // Método para atualizar os acertos na UI
    public void AtualizarAcertos(int acertos)
    {
        acertouTexto.text = acertos.ToString();
    }

    // Método para atualizar os erros na UI
    public void AtualizarErros(int erros)
    {
        errouTexto.text = erros.ToString();
    }

    // Método para limpar o texto da sequência de cores na UI
    public void LimparTexto()
    {
        sequenciaTexto.text = "";
    }

    // Método para atualizar a sequência de cores na UI
    public void AtualizarSequencia(string nomeDaCor)
    {
        sequenciaTexto.text += nomeDaCor + " ";  // Adiciona cada nome de cor à sequência
    }
}

