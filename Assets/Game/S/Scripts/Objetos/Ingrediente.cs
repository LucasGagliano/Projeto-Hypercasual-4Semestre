namespace Game.S.Scripts.Objetos
{
    using UnityEngine;
    
    public class Ingrediente : MonoBehaviour
    {
        #region Métodos

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