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

    // Array de sequência de números (índices) e de nomes (cores como string)
    public int[] sequencia;
    [SerializeField] string[] nomes;  // Array com os nomes das cores (strings)

    private void Start()
    {
        GerarSequencia();
    }

    // Método para gerar a sequência de cores aleatória
    void GerarSequencia()
    {
        corDaVez = 0;

        // A sequência será aleatória, mas com no mínimo 3 elementos e no máximo o tamanho de nomes[]
        sequencia = new int[Random.Range(3, nomes.Length)];

        // Limpa o texto na UI
        UIManager.instance.LimparTexto();

        // Gera a sequência e exibe cada item da sequência na UI
        for (int i = 0; i < sequencia.Length; i++)
        {
            sequencia[i] = Random.Range(0, nomes.Length); // Índices aleatórios do array de nomes
            UIManager.instance.AtualizarSequencia(nomes[sequencia[i]]);  // Atualiza a UI com o nome da cor
        }
    }

    // Método que o UIManager vai chamar para verificar se o jogador acertou
    public void ChecarCor(int corIndex)
    {
        // Verifica se a cor escolhida pelo jogador está correta
        if (corIndex == sequencia[corDaVez])
        {
            corDaVez++;  // Avança para a próxima cor da sequência

            // Se o jogador acertou toda a sequência, gera uma nova sequência e atualiza o número de acertos
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
            GerarSequencia();  // Gera uma nova sequência após erro
        }
    }
}
