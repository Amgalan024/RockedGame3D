using Rocket.Components.Enemy;
using Rocket.Models;
using Spawners;
using UnityEngine;

namespace Controllers.Gameplay
{
    public class EnemySpawnerController : MonoBehaviour
    {
        [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;
        [SerializeField] private EnemySpawner[] _enemySpawners;
        [SerializeField] private Transform _projectileContainer;

        private Transform _target;

        public void Awake()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized += PlayerModelInitialized;

            foreach (var enemySpawner in _enemySpawners)
            {
                void OnEnemySpawnedSubscription(EnemyInitializer enemyInitializer)
                {
                    OnEnemySpawned(enemyInitializer, enemySpawner);
                }

                enemySpawner.OnSpawned += OnEnemySpawnedSubscription;
            }
        }

        private void PlayerModelInitialized(PlayerModel playerModel)
        {
            _target = playerModel.RocketModel.RocketTransform;
        }

        private void OnEnemySpawned(EnemyInitializer enemyInitializer, EnemySpawner enemySpawner)
        {
            enemyInitializer.InitializeEnemy(_projectileContainer, _target);

            void OnEnemyDestroyedSubscription(bool b)
            {
                enemySpawner.DecreaseEnemyCount();
                enemyInitializer.EnemyModel.RocketModel.OnRocketDestroyed -= OnEnemyDestroyedSubscription;
            }

            enemyInitializer.EnemyModel.RocketModel.OnRocketDestroyed += OnEnemyDestroyedSubscription;
        }
    }
}