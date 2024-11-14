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
        // Inicialização do Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Se você quiser que o UIManager persista entre cenas
        }
        else if (instance != this)
        {
            Destroy(gameObject);  // Garante que apenas uma instância do UIManager exista
        }
    }
    #endregion

    [SerializeField] private Button[] botoes;   // Botões que o jogador pode clicar para escolher a cor
    [SerializeField] private TextMeshProUGUI sequenciaTexto;  // Texto para mostrar a sequência de cores
    [SerializeField] private TextMeshProUGUI errouTexto;     // Texto para mostrar erros
    [SerializeField] private TextMeshProUGUI acertouTexto;   // Texto para mostrar acertos

    private void Start()
    {
        // Atribuir o método de clique dos botões no start
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i;  // Para capturar o valor correto de "i" durante o loop
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(GameManager.instance.coresDisponiveis[x]));
        }
    }

    // Método para atualizar a quantidade de acertos
    public void AtualizarAcertos(int acertos)
    {
        acertouTexto.text = acertos.ToString();
    }

    // Método para atualizar a quantidade de erros
    public void AtualizarErros(int erros)
    {
        errouTexto.text = erros.ToString();
    }

    // Método para limpar o texto na tela
    public void LimparTexto()
    {
        sequenciaTexto.text = "";
    }

    // Método para atualizar a sequência exibida na UI
    public void AtualizarSequencia(string nomeDaCor)
    {
        sequenciaTexto.text += nomeDaCor + " ";  // Adiciona a cor à sequência de texto
    }
}






