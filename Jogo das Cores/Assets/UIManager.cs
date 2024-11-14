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
        // Adiciona listeners aos botões
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

    // Limpa o texto da sequência atual
    public void LimparTexto()
    {
        // Não precisamos mais limpar texto, mas podemos esconder a sequência visual temporariamente
        sequenciaImage.color = Color.clear;  // Deixa a imagem invisível (ou esconde a cor)
    }

    // Atualiza a sequência de cores na UI (usando imagens com cor)
    public void AtualizarSequencia(Color cor)
    {
        sequenciaImage.color = cor;  // Atualiza a cor da imagem
    }

    // Exibe toda a sequência de cores (pode ser útil para debug ou algum outro propósito)
    public void ExibirSequenciaCompleta()
    {
        // Vamos criar um painel ou outro tipo de visualização com as cores
        string sequenciaCompleta = "Sequência: ";
        foreach (Color cor in GameManager.instance.GetSequencia())
        {
            sequenciaCompleta += cor.ToString() + " ";  // Apenas para debug, podemos não mostrar isso
        }
        errouTexto.text = sequenciaCompleta;  // Aqui para exibir no texto de erros, se necessário
    }
}





