namespace Game.S.Scripts.Sistema
{
    using UnityEngine;
    
    public static class InformacoesGerais
    {
        public const string MusicaGroupName = "Musicas";
        public const string SomGroupName = "Sons";

        public static bool MusicaInstanciada;
        public static bool[] SonsMutados = new bool[2];

        public static GameObject MusicaObjeto;
    }
}