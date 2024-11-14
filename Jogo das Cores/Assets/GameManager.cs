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

    // Controle de jogo
    int corDaVez, acertos, erros;

    // Array de sequ�ncia de n�meros (�ndices) e de nomes (cores como string)
    public int[] sequencia;
    [SerializeField] string[] nomes;  // Array com os nomes das cores (strings)

    private void Start()
    {
        GerarSequencia();
    }

    // M�todo para gerar a sequ�ncia de cores aleat�ria
    void GerarSequencia()
    {
        corDaVez = 0;

        // A sequ�ncia ser� aleat�ria, mas com no m�nimo 3 elementos e no m�ximo o tamanho de nomes[]
        sequencia = new int[Random.Range(3, nomes.Length)];

        // Limpa o texto na UI
        UIManager.instance.LimparTexto();

        // Gera a sequ�ncia e exibe cada item da sequ�ncia na UI
        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = Random.Range(0, nomes.Length); // �ndices aleat�rios do array de nomes
            UIManager.instance.AtualizarSequencia(nomes[sequencia[i]]);  // Atualiza a UI com o nome da cor
        }
    }

    // M�todo que o UIManager vai chamar para verificar se o jogador acertou
    public void ChecarCor(int corIndex)
    {
        // Verifica se a cor escolhida pelo jogador est� correta
        if (corIndex == sequencia[corDaVez])
        {
            corDaVez++;  // Avan�a para a pr�xima cor da sequ�ncia

            // Se o jogador acertou toda a sequ�ncia, gera uma nova sequ�ncia e atualiza o n�mero de acertos
            if (corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia();
            }
        }
        else
        {
            erros++;  // Incrementa o contador de erros
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia();  // Gera uma nova sequ�ncia ap�s erro
        }
    }
}
