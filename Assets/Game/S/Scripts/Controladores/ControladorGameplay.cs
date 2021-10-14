using System;

namespace Game.S.Scripts.Controladores
{
    using UnityEngine;

    public class ControladorGameplay : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Privadas

        [SerializeField] [Tooltip("Referência para o painel de game over.")] private GameObject pnlGameover;
        [SerializeField] [Tooltip("Os objetos que sofreram um aumento em sua posição Y.")] private GameObject[] objetosParaSubir;
        [SerializeField] [Tooltip("Referência para o controlador de ingredientes.")] private ControladorIngredientes controladorIngredientes;
        [SerializeField] private float offsetSubir;

        private bool _encontrouControladorIngredientes;
        private bool[] _encontrouObjetosParaSubir;

        #endregion
        
        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Privados
        
        private void Start()
        {
            Time.timeScale = 1;
            _encontrouObjetosParaSubir = new bool[objetosParaSubir.Length];
            _encontrouControladorIngredientes = controladorIngredientes != null;
            
            for (var i = 0; i < objetosParaSubir.Length; i++)
                _encontrouObjetosParaSubir[i] = objetosParaSubir[i] != null;
        }

        #endregion

        #endregion

        #region Métodos Personalizados

        #region Métodos Públicos
        
        public void SubirObjetos()
        {
            if (!_encontrouControladorIngredientes) return;
            for (var i = 0; i < objetosParaSubir.Length; i++)
                if (_encontrouObjetosParaSubir[i])
                    objetosParaSubir[i].transform.Translate(0, controladorIngredientes.IngredienteInstanciado.GetComponent<BoxCollider2D>().size.y - offsetSubir , 0);
        }

        public void AlterarEstadoDoJogo(int i)
        {
            Time.timeScale = i;
        }

        public void GameOver()
        {
            pnlGameover.SetActive(true);
        }

        #endregion

        #endregion

        #endregion
    }
}