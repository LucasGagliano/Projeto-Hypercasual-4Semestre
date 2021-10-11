using System;

namespace Game.S.Scripts.Controladores
{
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ControladorUI : MonoBehaviour
    {
        #region Variáveis
        
        #region Variáveis Privadas
        
        [SerializeField] [Tooltip("Referência para o texto dos pontos durante a gameplay")] private Text txtPontos;
        private bool _encontrouTxtPontos;

        #endregion
        
        #endregion
        
        #region Métodos
        
        #region Métodos da Unity
        
        #region Métodos Privados
        
        private void Start()
        {
            _encontrouTxtPontos = txtPontos != null;
        }
        
        #endregion
        
        #endregion
        
        #region Métodos Personalizados
        
        #region Métodos Públicos

        public void AumentarPontos()
        {
            if (_encontrouTxtPontos)
                txtPontos.text = (Convert.ToInt32(txtPontos.text) + 1).ToString();
        }
        
        #endregion
        
        #endregion
        
        #endregion
    }
}

