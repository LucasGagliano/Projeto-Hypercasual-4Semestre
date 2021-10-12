namespace Game.S.Scripts.Objetos
{
    using UnityEngine;
    using Controladores;
    
    public class Ingrediente : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Privadas
        
        private ControladorIngredientes _controladorIngredientes;

        #endregion

        #endregion
        
        #region Métodos

        #region Métodos da Unity
        
        #region Métodos Privados

        private void Awake()
        {
            _controladorIngredientes = FindObjectOfType<ControladorIngredientes>();
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (!collision2D.collider.CompareTag("Ingrediente")) return;

            if (_controladorIngredientes.EncontrouIngredienteInstanciado && gameObject == _controladorIngredientes.IngredienteInstanciado.gameObject && _controladorIngredientes.PodeGerarPerfect)
            {
                _controladorIngredientes.PodeGerarPerfect = false;
                _controladorIngredientes.DetectarPerfect();
            }

            if (_controladorIngredientes.PodeInstanciarIngrediente)
                _controladorIngredientes.StartGerarIngredienteAposTempo();
        }

        #endregion
        
        #endregion
        
        #region Métodos Personalizados
    
        #region Métodos Públicos
        
        public void GerarCorpo()
        {
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
        }
        
        #endregion
    
        #endregion
    
        #endregion
    }
}