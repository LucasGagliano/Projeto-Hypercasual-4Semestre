namespace Game.S.Scripts.Controladores
{
    using System.Collections;
    using System.Linq;
    using UnityEngine;
    using Objetos;

    public class ControladorIngredientes : MonoBehaviour
    {
        #region Variáveis

        #region Variáveis Públicas

        public Ingrediente IngredienteInstanciado {get; set;}

        #endregion
        
        #region Variáveis Privadas
        
        [SerializeField] [Tooltip("Tempo de esperar para gerar um novo ingrediente.")] private float timer;
        [SerializeField] [Tooltip("Referência para o ingrediente que será instânciado.")] private Ingrediente[] ingredientes;
        [SerializeField] [Tooltip("Referência para o pai do objeto spawnado.")] private Pendulo pendulo;
        [SerializeField] [Tooltip("Posição que o objeto será instânciado.")] private Transform posicaoSpawn;
        [SerializeField] [Tooltip("Referência do painel de input.")] private ControladorInput painel;

        private bool _encontrouPendulo, _encontrouPosicaoSpawn, _encontrouPainel;
        private bool _encontrouIngredientes;
        
        #endregion
        
        #endregion
        
        #region Métodos

        #region Métodos da Unity

        #region Métodos Privados

        private void Start()
        {
            _encontrouPendulo = pendulo != null;
            _encontrouPosicaoSpawn = posicaoSpawn != null;
            _encontrouPainel = painel != null;

            var naoEncontrouIngrediente = ingredientes.Count(t => t == null);
            _encontrouIngredientes = naoEncontrouIngrediente == 0 && ingredientes.Length > 0;
            
            if (_encontrouIngredientes)
                GerarIngrediente();
            else
                Debug.LogWarning("Algum dos ingredientes que você colocou é nulo.");
        }

        #endregion

        #endregion
        
        #region Métodos Personalizados
        
        #region Métodos Públicos
        
        public void StartGerarIngredienteAposTempo()
        {
            if (_encontrouIngredientes)
                StartCoroutine(GerarIngredienteAposTempo());
        }
        
        #endregion
        
        #region Métodos Privados
        
        private IEnumerator GerarIngredienteAposTempo()
        {
            yield return new WaitForSeconds(timer);
            GerarIngrediente();
        }
        private void GerarIngrediente()
        {
            var rdnIngrediente = ingredientes[Random.Range(0, ingredientes.Length)];
            IngredienteInstanciado = _encontrouPendulo ? Instantiate(rdnIngrediente, pendulo.transform) : Instantiate(rdnIngrediente);
            
            if (_encontrouPosicaoSpawn)
                IngredienteInstanciado.transform.position =  posicaoSpawn.position;
            
            if (_encontrouPainel)
                painel.PodeGerarCorpoIngrediente = true;
        }

        #endregion
        
        #endregion
        
        #endregion
    }  
}