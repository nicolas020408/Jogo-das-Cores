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

    [SerializeField] Button[] botoes;
    [SerializeField] TextMeshProUGUI errouTexto, acertouTexto;
    [SerializeField] Image sequenciaImage;  // Usamos uma imagem para exibir a cor

    private void Start()
    {
        // Adiciona listeners aos bot�es
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i; // Captura o valor de "i" corretamente dentro do loop
            botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x));
        }
    }

    // Atualiza o contador de acertos na UI
    public void AtualizarAcertos(int acertos)
    {
        acertouTexto.text = acertos.ToString();
    }

    // Atualiza o contador de erros na UI
    public void AtualizarErros(int erros)
    {
        errouTexto.text = erros.ToString();
    }

    // Limpa o texto da sequ�ncia atual
    public void LimparTexto()
    {
        // N�o precisamos mais limpar texto, mas podemos esconder a sequ�ncia visual temporariamente
        sequenciaImage.color = Color.clear;  // Deixa a imagem invis�vel (ou esconde a cor)
    }

    // Atualiza a sequ�ncia de cores na UI (usando imagens com cor)
    public void AtualizarSequencia(Color cor)
    {
        sequenciaImage.color = cor;  // Atualiza a cor da imagem
    }

    // Exibe toda a sequ�ncia de cores (pode ser �til para debug ou algum outro prop�sito)
    public void ExibirSequenciaCompleta()
    {
        // Vamos criar um painel ou outro tipo de visualiza��o com as cores
        string sequenciaCompleta = "Sequ�ncia: ";
        foreach (Color cor in GameManager.instance.GetSequencia())
        {
            sequenciaCompleta += cor.ToString() + " ";  // Apenas para debug, podemos n�o mostrar isso
        }
        errouTexto.text = sequenciaCompleta;  // Aqui para exibir no texto de erros, se necess�rio
    }
}





