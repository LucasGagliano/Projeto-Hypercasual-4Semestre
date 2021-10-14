namespace Game.S.Scripts.Controladores
{
    using System.Collections.Generic;
    using Sistema;
    using UnityEngine;

    public class ControladorIcones : MonoBehaviour
    {
        [SerializeField] private GameObject[] botoesMusica;
        [SerializeField] private GameObject[] botoesSons;

        private GameObject[][] _botoes;
        private bool[] _encontrouBotoes;

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
        private void ConfiguracaoInicial(bool t, IReadOnlyList<GameObject> imagens)
        {
            imagens[0].SetActive(!t);
            imagens[1].SetActive(t);
        }
    }
}


