using UnityEngine;

namespace Frwk
{
    public class STSubManager<T> : BaseSTSubManager where T : BaseSTSubManager
    {
        private static T mInstance;
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    T component = FindObjectOfType<T>();
                    if (component == null)
                    {
                        var go = new GameObject();
                        component = go.AddComponent<T>();
                        component.name = component.GetType().Name;
                    }

                    mInstance = component;

                    GameManager.Instance.AddSubManager(component);
                }

                return mInstance;
            }
        }
    }
}