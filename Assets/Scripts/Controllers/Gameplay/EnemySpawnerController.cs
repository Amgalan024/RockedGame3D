using System;
using Rocket.Components.Enemy;
using Rocket.Models;
using Spawners;
using UnityEngine;

namespace Controllers.Gameplay
{
    public class EnemySpawnerController : MonoBehaviour
    {
        public event Action<EnemyInitializer> OnEnemyInitialized;
        [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;
        [SerializeField] private EnemySpawner[] _enemySpawners;
        [SerializeField] private Transform _projectileContainer;

        private Transform _target;

        public void Awake()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized += SetTarget;

            foreach (var enemySpawner in _enemySpawners)
            {
                void OnEnemySpawned(EnemyInitializer enemyInitializer)
                {
                    InitializeSpawnedEnemy(enemyInitializer, enemySpawner);
                }

                enemySpawner.OnSpawned += OnEnemySpawned;
            }
        }

        private void SetTarget(PlayerModel playerModel)
        {
            _target = playerModel.RocketModel.RocketTransform;
        }

        private void InitializeSpawnedEnemy(EnemyInitializer enemyInitializer, EnemySpawner enemySpawner)
        {
            enemyInitializer.InitializeEnemy(_projectileContainer, _target);

            void OnEnemyDestroyedSubscription(bool b)
            {
                enemySpawner.DecreaseEnemyCount();
                enemyInitializer.EnemyModel.RocketModel.OnRocketDestroyed -= OnEnemyDestroyedSubscription;
            }

            enemyInitializer.EnemyModel.RocketModel.OnRocketDestroyed += OnEnemyDestroyedSubscription;

            OnEnemyInitialized?.Invoke(enemyInitializer);
        }
    }
}