using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ContextManager
    {
        #region Singleton
        
        public static ContextManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContextManager();
                }

                return _instance;
            }
        }

        private static ContextManager _instance;
        
        #endregion

        private Dictionary<Type, BaseContext> _contexts;

        public bool TryAddElement<T>(T context) where T : BaseContext
        {
            if (_contexts == null)
            {
                _contexts = new Dictionary<Type, BaseContext>();
            }

            if (_contexts.ContainsKey(context.GetType()))
            {
                return false;
            }

            _contexts[context.GetType()] = context;
            return true;
        }

        public void OverrideElement<T>(T context) where T : BaseContext
        {
            if (_contexts == null)
            {
                _contexts = new Dictionary<Type, BaseContext>();
            }
            
            _contexts[context.GetType()] = context;
        }

        public bool TryGetElement<T>(out T value) where T : BaseContext
        {
            value = null;
            
            if (_contexts == null)
            {
                return false;
            }

            if (_contexts.TryGetValue(typeof(T), out var context))
            {
                value = context as T;
                return true;
            }
            
            return false;
        }
    }
}