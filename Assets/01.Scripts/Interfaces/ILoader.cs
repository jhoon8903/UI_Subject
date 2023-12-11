using System.Collections.Generic;

namespace _01.Scripts.Interfaces
{
    public interface ILoader<TKey, TValue>
    {
        Dictionary<TKey, TValue> CreateData();
    }
}