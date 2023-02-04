using UnityEngine;

using System.Collections.Generic;

namespace Frwk
{
    public class STManager<T> : MonoBehaviour where T : Component
    {
        private Dictionary<string, BaseSTSubManager> mSubMgrDic = new Dictionary<string, BaseSTSubManager>();

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

                    DontDestroyOnLoad(component.gameObject);
                }

                return mInstance;
            }
        }

        public void AddSubManager(BaseSTSubManager comp)
        {
            mSubMgrDic.Add(comp.name, comp);

            comp.transform.SetParent(transform);
        }

        public void ReleaseAll()
        {
            foreach (KeyValuePair<string, BaseSTSubManager> subMgr in mSubMgrDic)
            {
                subMgr.Value.Release();
            }
        }
    }
}