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
}
