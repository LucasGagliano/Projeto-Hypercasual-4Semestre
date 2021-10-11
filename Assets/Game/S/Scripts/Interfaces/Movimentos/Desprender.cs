namespace Game.S.Scripts.Movimentacao
{
    using UnityEngine;
    using Interfaces;
    
    public class Desprender : MonoBehaviour, IMovimentos
    {
        #region Métodos
    
        #region Métodos Personalizados
    
        #region Métodos Públicos
        
        public void Acao(Rigidbody2D _rigidbody2D, float force)
        {
            _rigidbody2D.gameObject.transform.parent = null;
        }
        
        #endregion
    
        #endregion
    
        #endregion
    }
}