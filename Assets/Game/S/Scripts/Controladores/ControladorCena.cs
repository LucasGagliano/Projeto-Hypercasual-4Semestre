namespace Game.S.Scripts.Controladores
{
    using UnityEngine;

    public class ControladorCena : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Privadas

        [SerializeField] [Tooltip("O uamento que os objetos selecionados sofreram em sua posição Y.")] private float aumentoVertical;
        [SerializeField] [Tooltip("Os objetos que sofreram um aumento em sua posição Y.")] private GameObject[] objetosParaSubir;
        private bool[] _encontrouObjetosParaSubir;

        #endregion
        
        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Privados
        
        private void Start()
        {
            _encontrouObjetosParaSubir = new bool[objetosParaSubir.Length];
        
            for (var i = 0; i < objetosParaSubir.Length; i++)
                _encontrouObjetosParaSubir[i] = objetosParaSubir[i] != null;
        }
        
        #endregion

        #endregion

        #region Métodos Personalizados

        #region Métodos Públicos
        
        public void SubirObjetos()
        {
            for (var i = 0; i < objetosParaSubir.Length; i++)
                if (_encontrouObjetosParaSubir[i])
                    objetosParaSubir[i].transform.Translate(0, aumentoVertical * Time.deltaTime, 0);
        }
        
        #endregion

        #endregion

        #endregion
    }
}