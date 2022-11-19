using Rocket;
using Rocket.Components.Enemy;
using Rocket.Models;
using Spawners;
using UnityEngine;

namespace Controllers.Gameplay
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;
        [SerializeField] private EnemySpawner _enemySpawner;

        private PlayerModel _playerModel;

        private void Awake()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized += OnPlayerModelInitialized;
            _enemySpawner.OnSpawned += InitializeEnemyRocket;
        }

        private void OnPlayerModelInitialized(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void InitializeEnemyRocket(EnemyInitializer enemyInitializer)
        {
            enemyInitializer.InitializeEnemy();

            enemyInitializer.GetComponent<EnemyAttackHandler>().PlayerRocketTransform =
                _playerModel.RocketModel.RocketTransform;

            enemyInitializer.GetComponent<EnemyMovementStrategy>().PlayerRocketTransform =
                _playerModel.RocketModel.RocketTransform;
        }
    }
}