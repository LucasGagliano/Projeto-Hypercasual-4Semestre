namespace Editor.S.Scripts.CustomEditors
{
    using UnityEngine;
    using UnityEditor;
    using Game.S.Scripts.Controladores;

    [CustomEditor(typeof(ControladorInput))]
    public class CustomEditorControladorInput : Editor
    {
        #region Variáveis

        #region Variáveis Privadas

        private SerializedProperty _controladorIngredientes, _controladorGameplay;
        private bool _encontrouControladorIngredientes, _encontrouControladorGameplay;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos

        public override void OnInspectorGUI()
        {
            if (_encontrouControladorIngredientes)
                EditorGUILayout.PropertyField(_controladorIngredientes, new GUIContent("Controlador de ingredientes:"));

            if (_encontrouControladorGameplay)
                EditorGUILayout.PropertyField(_controladorGameplay, new GUIContent("Controlador de gameplay:"));

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _controladorIngredientes = serializedObject.FindProperty("controladorIngredientes");
            _controladorGameplay = serializedObject.FindProperty("controladorGameplay");

            _encontrouControladorIngredientes = _controladorIngredientes != null;
            _encontrouControladorGameplay = _controladorGameplay != null;
        }

        #endregion

        #endregion

        #endregion
    }
}