namespace Game.S.Scripts.Controladores
{
    using UnityEngine;

    public class ControladorInput : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Públicas
    
        public bool PodeGerarCorpoIngrediente {get; set;}

        #endregion

        #region Variávies Privadas

        [SerializeField] [Tooltip("Referência para o controlador de ingredientes.")] private ControladorIngredientes controladorIngredientes;
        [SerializeField] [Tooltip("Referência para o controlador de cena.")] private ControladorGameplay controladorGameplay;
        private bool _encontrouControladorIngredientes;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity
    
        #region Métodos Privados

        private void Start()
        {
            PodeGerarCorpoIngrediente = true;
            _encontrouControladorIngredientes = controladorIngredientes != null;
        }

        #endregion

        #endregion
    
        #region Métodos Personalizados

        #region Métodos Públicos

        public void Clicado()
        {
            if (!PodeGerarCorpoIngrediente || !_encontrouControladorIngredientes) return;
            controladorIngredientes.IngredienteInstanciado.GerarCorpo();
            controladorGameplay.SubirObjetos();
            PodeGerarCorpoIngrediente = false;
        }

        #endregion
    
        #endregion

        #endregion
    }
}