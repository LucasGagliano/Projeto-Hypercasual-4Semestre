namespace Editor.S.Scripts.CustomEditors
{
    using UnityEngine;
    using UnityEditor;
    using Game.S.Scripts.Controladores;
    
    [CustomEditor(typeof(ControladorUI))]
    public class CustomEditorControladorUI : Editor
    {
        #region Variáveis

        #region Variáveis Privadas

        private SerializedProperty _txtPontos;
        private bool _encontrouTxtPontos;
        private bool _foldoutTextos;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos

        public override void OnInspectorGUI()
        {
            _foldoutTextos = EditorGUILayout.Foldout(_foldoutTextos, new GUIContent("Textos"));
            if (_foldoutTextos)
            {
                if (_encontrouTxtPontos)
                    EditorGUILayout.PropertyField(_txtPontos, new GUIContent("Pontos:"));
            }

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _txtPontos = serializedObject.FindProperty("txtPontos");

            _encontrouTxtPontos = _txtPontos != null;
        }

        #endregion

        #endregion

        #endregion
    }
}


