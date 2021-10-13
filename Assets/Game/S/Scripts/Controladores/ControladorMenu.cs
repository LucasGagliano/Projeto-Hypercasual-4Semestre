using Game.S.Scripts.Sistema;
using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    [SerializeField] private GameObject musica;
    private bool _encontrouMusica;
    
    private void Start()
    {
        _encontrouMusica = musica != null;
        if (!_encontrouMusica || InformacoesGerais.MusicaInstanciada) return;
        InstanciarMusica();
    }

    private void InstanciarMusica()
    {
        var musicaTmp = Instantiate(musica);
        InformacoesGerais.MusicaInstanciada = true;
        InformacoesGerais.MusicaObjeto = musicaTmp;
    }
}
