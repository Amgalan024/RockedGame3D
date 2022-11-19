using System;
using Rocket.Components.Enemy;
using UnityEngine;
using Utils;

namespace Spawners
{
    public class EnemySpawner : MonoBehaviour, ISpawner<EnemyInitializer>
    {
        public event Action<EnemyInitializer> OnSpawned;

        [SerializeField] private EnemyInitializer _enemyPrefab;
        [SerializeField] private float _spawnFrequency;
        [SerializeField] private int _maxEnemiesCount;
        [SerializeField] private int _currentEnemiesCount;

        public Pool<EnemyInitializer> Pool { get; set; }
        public float SpawnTimer { get; set; }

        private void Start()
        {
            SpawnTimer = _spawnFrequency;
        }

        private void Update()
        {
            Spawn();
        }

        public void InitializeSpawner()
        {
            Pool = new Pool<EnemyInitializer>(_enemyPrefab, _maxEnemiesCount, transform);

            Pool.AutoExpand = true;
        }

        public void Spawn()
        {
            if ((SpawnTimer <= 0) && (_currentEnemiesCount < _maxEnemiesCount))
            {
                var spawnedEnemy = Pool.GetFreeElement();
                OnSpawned?.Invoke(spawnedEnemy);

                spawnedEnemy.RocketModel.OnRocketDestroyed += OnEnemyDestroyed;

                SpawnTimer = _spawnFrequency;
                _currentEnemiesCount++;
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

        private void OnEnemyDestroyed(bool byPlayer)
        {
            SpawnTimer = _spawnFrequency;
            _currentEnemiesCount -= 1;
            Debug.Log($"currentEnemiesCount = {_currentEnemiesCount}");
        }
    }
}