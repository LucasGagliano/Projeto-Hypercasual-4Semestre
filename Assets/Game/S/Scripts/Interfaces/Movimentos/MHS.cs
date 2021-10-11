namespace Game.S.Scripts.Movimentacao
{
    using UnityEngine;
    using Interfaces;
    
    public class MHS : MonoBehaviour, IMovimentos
    {
        #region Métodos
    
        #region Métodos Personalizados
    
        #region Métodos Públicos
        
        public void Acao(Rigidbody2D _rigidbody2D, float force)
        {
            _rigidbody2D.rotation = force;
        }
        
        #endregion
    
        #endregion
    
        #endregion
    }
}