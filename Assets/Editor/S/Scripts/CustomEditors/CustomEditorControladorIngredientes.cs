namespace Editor.S.Scripts.CustomEditors
{
    using UnityEngine;
    using UnityEditor;
    using Game.S.Scripts.Controladores;

    [CustomEditor(typeof(ControladorIngredientes))]
    public class CustomEditorControladorIngredientes : Editor
    {
        #region Variáveis

        #region Variáveis Privadas

        private SerializedProperty _timer, _ingredientes, _pendulo, _posicaoSpawn, _painel, _offsetPerfect;
        private bool _encontrouTimer, _encontrouIngredientes, _encontrouPendulo, _encontrouPosicaoSpawn, _encontrouPainel, _encontrouOffsetPerfect;

        #endregion

        #endregion

        #region Métodos

        #region Métodos da Unity

        #region Métodos Públicos

        public override void OnInspectorGUI()
        {
            if (_encontrouTimer)
                EditorGUILayout.PropertyField(_timer, new GUIContent("Temporizador:"));
            
            if (_encontrouIngredientes)
                EditorGUILayout.PropertyField(_ingredientes, new GUIContent("Ingredientes:"));

            if (_encontrouPendulo)
                EditorGUILayout.PropertyField(_pendulo, new GUIContent("Pêndulo:"));

            if (_encontrouPosicaoSpawn)
                EditorGUILayout.PropertyField(_posicaoSpawn, new GUIContent("Posição de spawn:"));

            if (_encontrouPainel)
                EditorGUILayout.PropertyField(_painel, new GUIContent("Painel de Inputs:"));

            if (_encontrouOffsetPerfect)
                EditorGUILayout.PropertyField(_offsetPerfect, new GUIContent("Offset para perfect:"));

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Métodos Privados

        private void OnEnable()
        {
            _ingredientes = serializedObject.FindProperty("ingredientes");
            _pendulo = serializedObject.FindProperty("pendulo");
            _posicaoSpawn = serializedObject.FindProperty("posicaoSpawn");
            _timer = serializedObject.FindProperty("timer");
            _painel = serializedObject.FindProperty("painel");
            _offsetPerfect = serializedObject.FindProperty("offsetPerfect");

            _encontrouIngredientes = _ingredientes != null;
            _encontrouPendulo = _pendulo != null;
            _encontrouPosicaoSpawn = _posicaoSpawn != null;
            _encontrouTimer = _timer != null;
            _encontrouPainel = _painel != null;
            _encontrouOffsetPerfect = _offsetPerfect != null;
        }

        #endregion

        #endregion

        #endregion
    }
}