namespace Editor.S.Scripts.CustomEditors
{
    using UnityEngine;
    using UnityEditor;
    using Game.S.Scripts.Controladores;

    [CustomEditor(typeof(ControladorGameplay))]
    public class CustomEditorControladorGameplay : Editor
    {
        #region Variáveis

        #region Variáveis Privadas

        private SerializedProperty _pnlGamerover, _objetosParaSubir, _controladorIngredientes, _offsetSubir;
        private bool _encontrouPnlGameover, _encontrouObjetosParaSubir, _encontrouControladorIngredientes, _encontrouOffsetSubir;
        
        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos
        
        public override void OnInspectorGUI()
        {
            if (_encontrouPnlGameover)
                EditorGUILayout.PropertyField(_pnlGamerover, new GUIContent("Painel de gameover:"));

            if (_encontrouObjetosParaSubir)
                EditorGUILayout.PropertyField(_objetosParaSubir, new GUIContent("Objetos para movimentar:"));

            if (_encontrouControladorIngredientes)
                EditorGUILayout.PropertyField(_controladorIngredientes, new GUIContent("Controlador de ingredientes"));

            if (_encontrouOffsetSubir)
                EditorGUILayout.PropertyField(_offsetSubir, new GUIContent("Offset de translação:"));

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _pnlGamerover = serializedObject.FindProperty("pnlGameover");
            _objetosParaSubir = serializedObject.FindProperty("objetosParaSubir");
            _controladorIngredientes = serializedObject.FindProperty("controladorIngredientes");
            _offsetSubir = serializedObject.FindProperty("offsetSubir");

            _encontrouPnlGameover = _pnlGamerover != null;
            _encontrouObjetosParaSubir = _objetosParaSubir != null;
            _encontrouControladorIngredientes = _controladorIngredientes != null;
            _encontrouOffsetSubir = _offsetSubir != null;
        }
        
        #endregion

        #endregion

        #endregion
    }
}