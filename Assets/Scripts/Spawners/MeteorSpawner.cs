using System;
using Meteor;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class MeteorSpawner : MonoBehaviour, ISpawnerGeneric<MeteorInitializer>
    {
        public event Action<MeteorInitializer> OnSpawned;

        [SerializeField] private Transform _root; 
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private MeteorInitializer _meteorPrefab;
        [SerializeField] private float _spawnFrequency;
        [SerializeField] private int _poolCount;

        public Pool<MeteorInitializer> Pool { get; set; }
        public float SpawnTimer { get; set; }

        private void Start()
        {
            SpawnTimer = _spawnFrequency;
        }

        private void Update()
        {
            Spawn();
        }

        public void Initialize()
        {
            Pool = new Pool<MeteorInitializer>(_meteorPrefab, _poolCount, _root)
            {
                AutoExpand = true
            };
        }

        public void Spawn()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            if (SpawnTimer <= 0)
            {
                var spawnedMeteor = Pool.GetFreeElement(_spawnPoints[spawnPointIndex].position);

                OnSpawned?.Invoke(spawnedMeteor);

                SpawnTimer = _spawnFrequency;
            }

            CountDown();
        }

        public void CountDown()
        {
            if (SpawnTimer >= 0)
            {
                SpawnTimer -= Time.deltaTime;
            }
        }
    }
}