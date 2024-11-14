using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        // Verifique se a inst�ncia j� existe ou se n�o est� sendo duplicada
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

    public Color[] coresDisponiveis;  // Array de cores dispon�veis
    public Color[] sequencia;         // Sequ�ncia de cores gerada
    private int corDaVez = 0;         // Indica qual cor o jogador deve acertar

    public int acertos = 0;           // Contador de acertos
    public int erros = 0;             // Contador de erros

    private void Start()
    {
        // Garantir que o UIManager esteja inicializado antes de us�-lo
        if (UIManager.instance != null)
        {
            GerarSequencia();  // Gerar a sequ�ncia ao iniciar
        }
        else
        {
            Debug.LogError("UIManager n�o foi inicializado corretamente!");
        }
    }

    void GerarSequencia()
    {
        // Verifique se UIManager est� inicializado
        if (UIManager.instance != null)
        {
            corDaVez = 0;
            sequencia = new Color[Random.Range(3, coresDisponiveis.Length)];

            UIManager.instance.LimparTexto();  // Limpar texto da UI antes de mostrar nova sequ�ncia

            for (int i = 0; i < sequencia.Length; i++)
            {
                sequencia[i] = coresDisponiveis[Random.Range(0, coresDisponiveis.Length)];
                UIManager.instance.AtualizarSequencia(sequencia[i].ToString());  // Atualiza UI com a cor da sequ�ncia
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
                GerarSequencia();  // Gere uma nova sequ�ncia quando acertar tudo
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia();  // Gere uma nova sequ�ncia quando errar
        }
    }
}





