using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance=FindObjectOfType<T>();
                if (!instance)
                {
                    GameObject newGO = new GameObject();
                    instance = newGO.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        instance = this as T;
    }
}
