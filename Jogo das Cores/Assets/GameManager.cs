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
    public Color[] sequencia;  // A sequ�ncia de cores
    [SerializeField] Color[] coresDisponiveis; // Array de cores reais para escolha

    private void Start()
    {
        GerarSequencia();
    }

    // Gera uma nova sequ�ncia de cores aleat�ria
    void GerarSequencia()
    {
        corDaVez = 0;

        // A sequ�ncia ter� entre 3 e o comprimento de "coresDisponiveis"
        sequencia = new Color[Random.Range(3, coresDisponiveis.Length)];

        UIManager.instance.LimparTexto();

        // Preenche a sequ�ncia com cores aleat�rias
        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = coresDisponiveis[Random.Range(0, coresDisponiveis.Length)];
            UIManager.instance.AtualizarSequencia(sequencia[i]);
        }
    }

    // Checa se a cor clicada � a correta na sequ�ncia
    public void ChecarCor(int corIndex)
    {
        if (corIndex == corDaVez)
        {
            corDaVez++;
            if (corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia(); // Gera uma nova sequ�ncia ap�s acertar
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia(); // Gera uma nova sequ�ncia ap�s erro
        }
    }

    // M�todo que retorna a sequ�ncia de cores atual
    public Color[] GetSequencia()
    {
        return sequencia;
    }

    // M�todo que retorna o n�mero de acertos
    public int GetAcertos()
    {
        return acertos;
    }

    // M�todo que retorna o n�mero de erros
    public int GetErros()
    {
        return erros;
    }
}




