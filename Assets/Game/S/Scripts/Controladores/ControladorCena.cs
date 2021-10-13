namespace Game.S.Scripts.Controladores
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Sistema;
    
    public class ControladorCena : MonoBehaviour
    {
        public void CarregarCena(string nome)
        {
            SceneManager.LoadScene(nome, LoadSceneMode.Single);
            DontDestroyOnLoad(InformacoesGerais.MusicaObjeto);
        }
    }
}


