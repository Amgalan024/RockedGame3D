using System;
using UnityEngine;
using Utils;

namespace Spawners
{
    public interface ISpawnerGeneric<T> where T : MonoBehaviour
    {
        event Action<T> OnSpawned;
        
        Pool<T> Pool { set; get; }
        float SpawnTimer { get; }
        void Initialize();
        void Spawn();
        void CountDown();
    }
}