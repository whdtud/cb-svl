using UnityEngine;

using System;

public class SingleGOBuilder : MonoBehaviour
{
    public static T Build<T>() where T : Component
    {
        T component = FindObjectOfType<T>();
        if (component == null)
        {
            var go = new GameObject();
            component = go.AddComponent<T>();
            component.name = component.GetType().Name;
        }

        DontDestroyOnLoad(component.gameObject);

        return component;
    }
}
