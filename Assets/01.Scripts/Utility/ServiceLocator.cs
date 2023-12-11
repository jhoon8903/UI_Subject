using System;
using System.Collections.Generic;
using UnityEngine;

namespace _01.Scripts.Utility
{
    public class ServiceLocator
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
}
