namespace Game.S.Scripts.Controladores
{
    using System;
    using System.Collections;
    using System.Globalization;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ControladorUI : MonoBehaviour
    {
        #region Variáveis
        
        #region Variáveis Privadas
        
        [SerializeField] [Tooltip("Referência para o texto dos pontos durante a gameplay.")] private Text txtPontos;
        [SerializeField] [Tooltip("Referência para o texto do timer.")] private Text txtTimer;
        [SerializeField] [Tooltip("Referência para a imagem do timer.")] private Image imgTimer;
        [SerializeField] [Tooltip("Referência para o controlador de ingredientes.")] private ControladorIngredientes controladorIngredientes;
        [SerializeField] [Tooltip("Referência para o painel que impede input de apressadinhos.")] private GameObject painelContraInput;

        private bool _encontrouTxtPontos, _encontrouTxtTimer, _encontrouImgTimer, _encontrouControladorIngredientes, _encontrouPainelContraInput;

        #endregion
        
        #endregion
        
        #region Métodos
        
        #region Métodos da Unity
        
        #region Métodos Privados
        
        private void Start()
        {
            _encontrouTxtPontos = txtPontos != null;
            _encontrouTxtTimer = txtTimer != null;
            _encontrouImgTimer = imgTimer != null;
            _encontrouControladorIngredientes = controladorIngredientes != null;
            _encontrouPainelContraInput = painelContraInput != null;
            StartCoroutine(ExecutarTimer());
        }
        
        #endregion
        
        #endregion
        
        #region Métodos Personalizados
        
        #region Métodos Privados

        private IEnumerator ExecutarTimer()
        {
            if (!_encontrouImgTimer || !_encontrouTxtTimer) yield break;
            var cor = txtTimer.color;

            yield return new WaitForSeconds(3f);
            imgTimer.gameObject.SetActive(true);
            for (var i = 3; i > 0; i--)
            {
                txtTimer.text = i.ToString(CultureInfo.CurrentCulture);
                for (int j = 0, x = 150; j < x; j++)
                {
                    txtTimer.color = new Color(cor.r, cor.g, cor.b, (255f - j) / 255f);
                    yield return new WaitForSeconds(1.3f / x);
                }
            }
            imgTimer.gameObject.SetActive(false);
            
            if (_encontrouPainelContraInput)
                Destroy(painelContraInput);
        }

        #endregion
        
        #region Métodos Públicos

        public void AumentarPontos()
        {
            controladorIngredientes.Pontos++;
            
            if (_encontrouTxtPontos)
                txtPontos.text = controladorIngredientes.Pontos.ToString();
        }
        
        #endregion
        
        #endregion
        
        #endregion
    }
}

