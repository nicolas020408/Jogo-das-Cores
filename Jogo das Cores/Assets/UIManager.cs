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
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion


    [SerializeField] Button[] botoes;

    [SerializeField] TextMeshProUGUI sequenciaTexto, errouTexto, acertouTexto;

    private void Start()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            int x = i;
            //botoes[i].onClick.AddListener(() => GameManager.instance.ChecarCor(x))
        }
    }
}
