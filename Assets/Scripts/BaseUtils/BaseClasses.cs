using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BaseUtils
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object _instanceLock = new object();
        public static T Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }
            }
            private set
            {
                _instance = value;
            }
        }
    }
}