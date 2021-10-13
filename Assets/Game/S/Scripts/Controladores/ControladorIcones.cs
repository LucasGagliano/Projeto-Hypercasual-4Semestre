using Game.S.Scripts.Sistema;
using UnityEngine;

public class ControladorIcones : MonoBehaviour
{
    [SerializeField] private GameObject[] botoesMusica;
    [SerializeField] private GameObject[] botoesSons;
    // fazer verificador dos dois acima
    
        
    private void Start()
    {
        ConfiguracaoInicial();
    }
    private void ConfiguracaoInicial()
    {
        if (InformacoesGerais.MusicaMutada)
        {
            botoesMusica[0].SetActive(false);
            botoesMusica[1].SetActive(true);
        }
        else
        {
            botoesMusica[0].SetActive(true);
            botoesMusica[1].SetActive(false);
        }
            
        if (InformacoesGerais.SomMutado)
        {
            botoesSons[0].SetActive(false);
            botoesSons[1].SetActive(true);
        }
        else
        {
            botoesSons[0].SetActive(true);
            botoesSons[1].SetActive(false);
        }
    }
}
