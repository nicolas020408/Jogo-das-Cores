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
        // Inicializa��o do Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Se voc� quiser que o UIManager persista entre cenas
        }
        else if (instance != this)
        {
            Destroy(gameObject);  // Garante que apenas uma inst�ncia do UIManager exista
        }
    }
    #endregion

    [SerializeField] private Button[] botoes;   // Bot�es que o jogador pode clicar para escolher a cor
    [SerializeField] private TextMeshProUGUI sequenciaTexto;  // Texto para mostrar a sequ�ncia de cores
    [SerializeField] private TextMeshProUGUI errouTexto;     // Texto para mostrar erros
    [SerializeField] private TextMeshProUGUI acertouTexto;   // Texto para mostrar acertos

    private void Start()
    {
        // Atribuir o m�todo de clique dos bot�es no start
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i;  // Para capturar o valor correto de "i" durante o loop
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(GameManager.instance.coresDisponiveis[x]));
        }
    }

    // M�todo para atualizar a quantidade de acertos
    public void AtualizarAcertos(int acertos)
    {
        acertouTexto.text = acertos.ToString();
    }

    // M�todo para atualizar a quantidade de erros
    public void AtualizarErros(int erros)
    {
        errouTexto.text = erros.ToString();
    }

    // M�todo para limpar o texto na tela
    public void LimparTexto()
    {
        sequenciaTexto.text = "";
    }

    // M�todo para atualizar a sequ�ncia exibida na UI
    public void AtualizarSequencia(string nomeDaCor)
    {
        sequenciaTexto.text += nomeDaCor + " ";  // Adiciona a cor � sequ�ncia de texto
    }
}






