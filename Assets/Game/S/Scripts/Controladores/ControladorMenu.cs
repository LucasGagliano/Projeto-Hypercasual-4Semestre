namespace Game.S.Scripts.Controladores
{
    using Sistema;
    using UnityEngine;

    public class ControladorMenu : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Privadas

        [SerializeField] private GameObject musica;
        private bool _encontrouMusica;

        #endregion

        #endregion

        #region Métodos

        #region Métodos Unity

        #region Métodos Privados

        private void Start()
        {
            _encontrouMusica = musica != null;
            if (!_encontrouMusica || InformacoesGerais.MusicaInstanciada) return;
            InstanciarMusica();
        }

        #endregion

        #endregion

        #region Métodos Personalizados

        #region Métodos Privados

        private void InstanciarMusica()
        {
            var musicaTmp = Instantiate(musica);
            InformacoesGerais.MusicaInstanciada = true;
            InformacoesGerais.MusicaObjeto = musicaTmp;
        }

        #endregion

        #endregion

        #endregion
    }
}