using System;
using Items;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class ItemSpawner : MonoBehaviour, ISpawner<ItemBase>
    {
        public event Action<ItemBase> OnSpawned;

        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private ItemBase _itemBasePrefab;
        [SerializeField] private float _spawnFrequency;
        [SerializeField] private int _poolCount;
        [SerializeField] private int _spawnChance;

        public float SpawnTimer { get; set; }
        public Pool<ItemBase> Pool { get; set; }

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
            Pool = new Pool<ItemBase>(_itemBasePrefab, _poolCount, transform)
            {
                AutoExpand = true
            };
        }

        public void Spawn()
        {
            if (SpawnTimer <= 0)
            {
                int randomChance = Random.Range(0, 100);

                if (randomChance <= _spawnChance)
                {
                    int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

                    var spawnedItem = Pool.GetFreeElement(_spawnPoints[spawnPointIndex].position);
                    OnSpawned?.Invoke(spawnedItem);

                    SpawnTimer = _spawnFrequency;
                }
                else
                {
                    SpawnTimer = _spawnFrequency;
                }
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