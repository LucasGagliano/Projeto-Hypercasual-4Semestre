namespace Game.S.Scripts.Controladores
{
    using UnityEngine;
    using UnityEngine.Audio;
    using Sistema;
    
    public class ControladorOpcoes : MonoBehaviour
    {
        public void AtivarSom(AudioMixerGroup group)
        {
            group.audioMixer.SetFloat("volume", 0);
            AlterarSistema(group.name, true);
        }
        public void DesativarSom(AudioMixerGroup group)
        {
            group.audioMixer.SetFloat("volume", -80);
            AlterarSistema(group.name, false);
        }
        private void AlterarSistema(string nome, bool act)
        {
            switch (nome)
            {
                case InformacoesGerais.MusicaGroupName:
                    InformacoesGerais.MusicaMutada = !act;
                    break;
                
                case InformacoesGerais.SomGroupName:
                    InformacoesGerais.SomMutado = !act;
                    break;
            }
        }
    }
}


