using System;
using UnityEngine;
using Utils;

namespace Spawners
{
    public interface ISpawner<T> where T : MonoBehaviour
    {
        event Action<T> OnSpawned; 
        float SpawnTimer { set; get; }
        Pool<T> Pool { set; get; }
        void Spawn();
        void CountDown();
    }
}