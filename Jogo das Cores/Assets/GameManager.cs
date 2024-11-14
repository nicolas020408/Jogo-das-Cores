using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        // Verifique se a instância já existe ou se não está sendo duplicada
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

    public Color[] coresDisponiveis;  // Array de cores disponíveis
    public Color[] sequencia;         // Sequência de cores gerada
    private int corDaVez = 0;         // Indica qual cor o jogador deve acertar

    public int acertos = 0;           // Contador de acertos
    public int erros = 0;             // Contador de erros

    private void Start()
    {
        // Garantir que o UIManager esteja inicializado antes de usá-lo
        if (UIManager.instance != null)
        {
            GerarSequencia();  // Gerar a sequência ao iniciar
        }
        else
        {
            Debug.LogError("UIManager não foi inicializado corretamente!");
        }
    }

    void GerarSequencia()
    {
        // Verifique se UIManager está inicializado
        if (UIManager.instance != null)
        {
            corDaVez = 0;
            sequencia = new Color[Random.Range(3, coresDisponiveis.Length)];

            UIManager.instance.LimparTexto();  // Limpar texto da UI antes de mostrar nova sequência

            for (int i = 0; i < sequencia.Length; i++)
            {
                sequencia[i] = coresDisponiveis[Random.Range(0, coresDisponiveis.Length)];
                UIManager.instance.AtualizarSequencia(sequencia[i].ToString());  // Atualiza UI com a cor da sequência
            }
        }
    }

    public void ChecarCor(Color corSelecionada)
    {
        if (corSelecionada == sequencia[corDaVez])
        {
            corDaVez++;
            if (corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia();  // Gere uma nova sequência quando acertar tudo
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia();  // Gere uma nova sequência quando errar
        }
    }
}





