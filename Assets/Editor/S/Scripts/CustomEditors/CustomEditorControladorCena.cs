namespace Editor.S.Scripts.CustomEditors
{
    using UnityEngine;
    using UnityEditor;
    using Game.S.Scripts.Controladores;

    [CustomEditor(typeof(ControladorCena))]
    public class CustomEditorControladorCena : Editor
    {
        #region Variáveis

        #region Variáveis Privadas

        private SerializedProperty _aumentoVertical, _objetosParaSubir;
        private bool _encontrouAumentoVertical, _encontrouObjetosParaSubir;
        
        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos
        
        public override void OnInspectorGUI()
        {
            if (_encontrouAumentoVertical)
                EditorGUILayout.PropertyField(_aumentoVertical, new GUIContent("Aumento vertical:"));

            if (_encontrouObjetosParaSubir)
                EditorGUILayout.PropertyField(_objetosParaSubir, new GUIContent("Objetos para movimentar:"));

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _aumentoVertical = serializedObject.FindProperty("aumentoVertical");
            _objetosParaSubir = serializedObject.FindProperty("objetosParaSubir");

            _encontrouAumentoVertical = _aumentoVertical != null;
            _encontrouObjetosParaSubir = _objetosParaSubir != null;
        }
        
        #endregion

        #endregion

        #endregion
    }
}