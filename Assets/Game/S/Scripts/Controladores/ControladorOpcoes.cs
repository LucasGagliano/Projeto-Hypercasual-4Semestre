namespace Game.S.Scripts.Controladores
{
    using UnityEngine;
    using UnityEngine.Audio;
    using Sistema;
    using System.Collections.Generic;
    
    public class ControladorOpcoes : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Privadas

        [SerializeField] private GameObject[] botoesMusica;
        [SerializeField] private GameObject[] botoesSons;

        private GameObject[][] _botoes;
        private bool[] _encontrouBotoes;

        #endregion

        #endregion
        
        #region Métodos

        #region Métodos da Unity

        #region Métodos Privados

        private void Start()
        {
            var tmp = 0;
            
            _botoes = new[] {botoesMusica, botoesSons};
            _encontrouBotoes = new bool[2];
            
            
            for (var i = 0; i < _botoes.Length; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    if (_botoes[i][j] == null)
                        tmp++;
                }

                if (tmp > 0)
                    _encontrouBotoes[i] = false;

                tmp = 0;
            }

            for (var i = 0; i < _botoes.Length; i++)
                if (_encontrouBotoes[i])
                    ConfiguracaoInicial(InformacoesGerais.SonsMutados[i], _botoes[i]);
        }

        #endregion

        #endregion
        
        #region Métodos Personalizados

        #region Métodos Públicos
        
        public void AtivarSom(AudioMixerGroup group)
        {
            group.audioMixer.SetFloat("volume", 0);
            AlterarSistema(group.name, true);
        }
        public void DesativarSom(AudioMixerGroup group)
        {
            group.audioMixer.SetFloat("volume", -80);
            AlterarSistema(group.name, false);
        }
        
        #endregion

        #region Métodos Privados

        private void AlterarSistema(string nome, bool act)
        {
            switch (nome)
            {
                case InformacoesGerais.MusicaGroupName:
                    InformacoesGerais.SonsMutados[0] = !act;
                    break;
                
                case InformacoesGerais.SomGroupName:
                    InformacoesGerais.SonsMutados[1] = !act;
                    break;
            }
        }
        private void ConfiguracaoInicial(bool t, IReadOnlyList<GameObject> imagens)
        {
            imagens[0].SetActive(!t);
            imagens[1].SetActive(t);
        }

        #endregion

        #endregion

        #endregion
    }
}