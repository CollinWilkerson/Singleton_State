using UnityEngine;

namespace Chapter.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            //when any object tries to get the public instance of the singleton it will run this
            get
            {
                //if the static instance does not exist it will search the unity scene for one
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();

                    //if no instance exists it will create a new one
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            //if no instance exists make a new one
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else //else remove the duplicate
            {
                Destroy(gameObject);
            }
        }
    }
}
