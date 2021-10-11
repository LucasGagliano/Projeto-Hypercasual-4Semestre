namespace Editor.S.Scripts.CustomEditors
{
    using UnityEngine;
    using UnityEditor;
    using Game.S.Scripts.Objetos;

    [CustomEditor(typeof(Pendulo))]
    public class CustomEditorPendulo : Editor
    {
        #region Variáveis

        #region Variáveis Privadas

        private SerializedProperty _anguloMaximo, _velocidade;
        private bool _encontrouAnguloMaximo, _encontrouVelocidade;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos

        public override void OnInspectorGUI()
        {
            if (_encontrouAnguloMaximo)
                EditorGUILayout.PropertyField(_anguloMaximo, new GUIContent("Ângulo de abertura:"));

            if (_encontrouVelocidade)
                EditorGUILayout.PropertyField(_velocidade, new GUIContent("Velocidade:"));
            
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _anguloMaximo = serializedObject.FindProperty("anguloMaximo");
            _velocidade = serializedObject.FindProperty("velocidade");

            _encontrouAnguloMaximo = _anguloMaximo != null;
            _encontrouVelocidade = _velocidade != null;
        }

        #endregion

        #endregion

        #endregion
    }
}