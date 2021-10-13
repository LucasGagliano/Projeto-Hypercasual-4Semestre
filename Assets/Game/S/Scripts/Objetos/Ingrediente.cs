using UnityEngine.Audio;

namespace Game.S.Scripts.Objetos
{
    using UnityEngine;
    using Controladores;
    
    public class Ingrediente : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Privadas

        private AudioSource _som;
        private ControladorIngredientes _controladorIngredientes;
        private ControladorGameplay _controladorGameplay;

        // Fazer checagem
        
        #endregion

        #endregion
        
        #region Métodos

        #region Métodos da Unity
        
        #region Métodos Privados

        private void Awake()
        {
            _controladorIngredientes = FindObjectOfType<ControladorIngredientes>();
            _controladorGameplay = FindObjectOfType<ControladorGameplay>();
            _som = GameObject.Find("Bater").GetComponent<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.collider.CompareTag("Morrer"))
                _controladorGameplay.GameOver();
            
            if (!collision2D.collider.CompareTag("Ingrediente")) return;

            _som.Play();
            
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