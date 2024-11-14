using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    int corDaVez, acertos, erros;
    public Color[] sequencia;  // A sequência de cores
    [SerializeField] Color[] coresDisponiveis; // Array de cores reais para escolha

    private void Start()
    {
        GerarSequencia();
    }

    // Gera uma nova sequência de cores aleatória
    void GerarSequencia()
    {
        corDaVez = 0;

        // A sequência terá entre 3 e o comprimento de "coresDisponiveis"
        sequencia = new Color[Random.Range(3, coresDisponiveis.Length)];

        UIManager.instance.LimparTexto();

        // Preenche a sequência com cores aleatórias
        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = coresDisponiveis[Random.Range(0, coresDisponiveis.Length)];
            UIManager.instance.AtualizarSequencia(sequencia[i]);
        }
    }

    // Checa se a cor clicada é a correta na sequência
    public void ChecarCor(int corIndex)
    {
        if (corIndex == corDaVez)
        {
            corDaVez++;
            if (corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia(); // Gera uma nova sequência após acertar
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia(); // Gera uma nova sequência após erro
        }
    }

    // Método que retorna a sequência de cores atual
    public Color[] GetSequencia()
    {
        return sequencia;
    }

    // Método que retorna o número de acertos
    public int GetAcertos()
    {
        return acertos;
    }

    // Método que retorna o número de erros
    public int GetErros()
    {
        return erros;
    }
}




