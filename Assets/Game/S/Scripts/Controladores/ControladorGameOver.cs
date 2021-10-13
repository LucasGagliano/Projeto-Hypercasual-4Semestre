using System;
using System.Collections;
using Game.S.Scripts.Controladores;
using UnityEngine;
using UnityEngine.UI;

public class ControladorGameOver : MonoBehaviour
{
    [SerializeField] private Text txtPontos;
    [SerializeField] private Text txtHighscore;
    [SerializeField] private ControladorIngredientes controladorIngredientes;
    // Fazer checagem
    
    private void Start()
    {
        StartCoroutine(AtualizarPontos());
    }

    private IEnumerator AtualizarPontos()
    {
        if (controladorIngredientes.Pontos > PlayerPrefs.GetInt("Highscore"))
            PlayerPrefs.SetInt("Highscore", controladorIngredientes.Pontos);
        
        for (var i = 0; i < controladorIngredientes.Pontos; i++)
        {
            txtPontos.text = (Convert.ToInt32(txtPontos.text) + 1).ToString();
            yield return new WaitForSeconds(0.25f);
        }

        txtHighscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
