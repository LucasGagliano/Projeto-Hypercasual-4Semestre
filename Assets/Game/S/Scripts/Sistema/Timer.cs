namespace Game.S.Scripts.Sistema
{
    using System.Collections;
    using System;
    using UnityEngine;
    
    public static class Timer
    {
        #region Métodos
    
        #region Métodos Personalizados
        
        #region Métodos Públicos
    
        public static void CallWithDelay(this MonoBehaviour mono, Action method, float delay)
        {
            mono.StartCoroutine(CallWithDelayRoutine(method, delay));
        }
        public static void CallWithDelay<T>(this MonoBehaviour mono, Action<T> method, float delay, T parameter)
        {
            mono.StartCoroutine(CallWithDelayRoutine(method, delay, parameter));
        }
        
        #region Métodos Privados
        
        private static IEnumerator CallWithDelayRoutine(Action method, float delay)
        {
            yield return new WaitForSeconds(delay);
            method();
        }
        private static IEnumerator CallWithDelayRoutine<T>(Action<T> method, float delay, T parameter)
        {
            yield return new WaitForSeconds(delay);
            method(parameter);
        }
        
        #endregion
        
        #endregion
        
        #endregion
        
        #endregion
    }
}