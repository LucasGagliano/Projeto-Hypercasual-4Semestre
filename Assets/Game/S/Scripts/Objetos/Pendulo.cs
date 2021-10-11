namespace Game.S.Scripts.Objetos
{
    using UnityEngine;
    using Movimentacao;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Pendulo : MonoBehaviour
    {
        #region Variáveis
    
        #region Variáveis Privadas
        
        [SerializeField] [Tooltip("O ângulo máximo de abertura do movimento pendular.")] private float anguloMaximo;
        [SerializeField] [Tooltip("A velocidade de abertura.")] private float velocidade;
    
        private Rigidbody2D _rigidbody2D;
        private MHS _mhs;
        
        #endregion
        
        #endregion
    
        #region Métodos
    
        #region Métodos da Unity
    
        #region Métodos Privados
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _mhs = gameObject.AddComponent<MHS>();
        }

        private void Update()
        {
            _mhs.Acao(_rigidbody2D, anguloMaximo * Mathf.Sin(Time.time * velocidade));
        }
        
        #endregion
    
        #endregion
    
        #endregion
    }
}