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

        private SerializedProperty _controladorIngredientes, _controladorCena;
        private bool _encontrouControladorIngredientes, _encontrouControladoCena;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos

        public override void OnInspectorGUI()
        {
            if (_encontrouControladorIngredientes)
                EditorGUILayout.PropertyField(_controladorIngredientes, new GUIContent("Controlador de ingredientes:"));

            if (_encontrouControladoCena)
                EditorGUILayout.PropertyField(_controladorCena, new GUIContent("Controlador de cena:"));

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _controladorIngredientes = serializedObject.FindProperty("controladorIngredientes");
            _controladorCena = serializedObject.FindProperty("controladoCena");

            _encontrouControladorIngredientes = _controladorIngredientes != null;
            _encontrouControladoCena = _controladorCena != null;
        }

        #endregion

        #endregion

        #endregion
    }
}