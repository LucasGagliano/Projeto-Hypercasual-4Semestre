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

        private SerializedProperty _txtPontos, _txtTimer, _imgTimer, _controladorIngredientes, _painelContraInput;
        private bool _encontrouTxtPontos, _encontrouTxtTimer, _encontrouImgTimer, _encontrouControladorIngredientes, _encontrouPainelContraInput;
        private bool _foldoutTextos, _foldoutImagens;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos

        public override void OnInspectorGUI()
        {
            if (_encontrouControladorIngredientes)
                EditorGUILayout.PropertyField(_controladorIngredientes, new GUIContent("Controlador de ingredientes:"));

            if (_encontrouPainelContraInput)
            {
                EditorGUILayout.PropertyField(_painelContraInput, new GUIContent("Painel contra input:"));
                EditorGUILayout.Space();
            }

            _foldoutTextos = EditorGUILayout.Foldout(_foldoutTextos, new GUIContent("Textos"));
            if (_foldoutTextos)
            {
                if (_encontrouTxtPontos)
                    EditorGUILayout.PropertyField(_txtPontos, new GUIContent("Pontos:"));

                if (_encontrouTxtTimer)
                    EditorGUILayout.PropertyField(_txtTimer, new GUIContent("Timer:"));
            }

            _foldoutImagens = EditorGUILayout.Foldout(_foldoutImagens, new GUIContent("Imagens"));
            if (_foldoutImagens)
            {
                if (_encontrouImgTimer)
                    EditorGUILayout.PropertyField(_imgTimer, new GUIContent("Timer:"));
            }

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _txtPontos = serializedObject.FindProperty("txtPontos");
            _txtTimer = serializedObject.FindProperty("txtTimer");
            _imgTimer = serializedObject.FindProperty("imgTimer");
            _controladorIngredientes = serializedObject.FindProperty("controladorIngredientes");
            _painelContraInput = serializedObject.FindProperty("painelContraInput");
            
            _encontrouTxtPontos = _txtPontos != null;
            _encontrouTxtTimer = _txtTimer != null;
            _encontrouImgTimer = _imgTimer != null;
            _encontrouControladorIngredientes = _controladorIngredientes != null;
            _encontrouPainelContraInput = _painelContraInput != null;
        }

        #endregion

        #endregion

        #endregion
    }
}


