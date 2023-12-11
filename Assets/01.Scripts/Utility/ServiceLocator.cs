using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static readonly Dictionary<Type, object> Services = new();

    public static void RegisterService<T>(T service)
    {
        Services[typeof(T)] = service;
    }

    public static T GetService<T>()
    {
        return (T)Services[typeof(T)];
    }
}
