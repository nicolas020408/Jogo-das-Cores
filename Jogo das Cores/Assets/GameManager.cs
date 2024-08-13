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
    int[] sequencia;
    [SerializeField] string[] nomes;

    private void Start()
    {
        GerarSequencia();
    }

    void GerarSequencia()
    {
        corDaVez = 0;

        sequencia = new int[Random.Range(3, nomes.Length)];
        //UIManager.instance.LimparTexto();

        for(int i = 0; i < sequencia.Length; i++) 
        {
            sequencia[i] = Random.Range(0, nomes.Length);
            //UIManager.instance.AtualizarSequencia(nomes[sequencia[i]])
        }
    }
}