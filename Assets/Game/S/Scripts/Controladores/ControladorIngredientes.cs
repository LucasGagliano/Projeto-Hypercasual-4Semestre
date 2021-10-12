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

        public bool EncontrouIngredienteInstanciado {get; private set;}
        public bool PodeInstanciarIngrediente {get; private set;}
        public bool PodeGerarPerfect {get; set;}
        public Ingrediente IngredienteInstanciado {get; private set;}
        public Ingrediente IngredienteAnterior {get; set;}

        #endregion
        
        #region Variáveis Privadas
        
        [SerializeField] [Tooltip("Tempo de esperar para gerar um novo ingrediente.")] private float timer;
        [SerializeField] [Tooltip("O offset de distância para gerar um perfect.")] private float offsetPerfect;
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
            EncontrouIngredienteInstanciado = false;
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
            if (!_encontrouIngredientes || !PodeInstanciarIngrediente) return;
            PodeInstanciarIngrediente = false;
            StartCoroutine(GerarIngredienteAposTempo());
            EncontrouIngredienteInstanciado = !EncontrouIngredienteInstanciado || EncontrouIngredienteInstanciado;
        }

        public void DetectarPerfect()
        {
            var posicaoIngredienteAtual = IngredienteInstanciado.transform.position;
            var posicaoIngredienteAnterior = IngredienteAnterior.transform.position;
            var perfect = posicaoIngredienteAtual.x >= posicaoIngredienteAnterior.x - offsetPerfect && posicaoIngredienteAtual.x <= posicaoIngredienteAnterior.x + offsetPerfect;
            
            Debug.Log(perfect ? "Perfect" : "Not perfect");
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
            if (EncontrouIngredienteInstanciado)
                IngredienteAnterior = IngredienteInstanciado;
            
            var rdnIngrediente = ingredientes[Random.Range(0, ingredientes.Length)];
            IngredienteInstanciado = _encontrouPendulo ? Instantiate(rdnIngrediente, pendulo.transform) : Instantiate(rdnIngrediente);
            
            if (_encontrouPosicaoSpawn)
                IngredienteInstanciado.transform.position =  posicaoSpawn.position;
            
            if (_encontrouPainel)
                painel.PodeGerarCorpoIngrediente = true;

            PodeGerarPerfect = PodeInstanciarIngrediente = true;
        }

        #endregion
        
        #endregion
        
        #endregion
    }  
}