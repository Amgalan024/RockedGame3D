using Meteor;
using Rocket.Components.Enemy;
using Rocket.Models;
using Spawners;
using UnityEngine;

namespace Controllers.Gameplay
{
    public class PlayerScoreController : MonoBehaviour
    {
        [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;
        [SerializeField] private MeteorSpawner _meteorSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;

        private PlayerModel _playerModel;

        private void Awake()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized += OnPlayerModelInitialized;
            _meteorSpawner.OnSpawned += OnMeteorSpawned;
            _enemySpawner.OnSpawned += OnEnemySpawned;
        }

        private void OnPlayerModelInitialized(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void OnMeteorSpawned(MeteorInitializer meteor)
        {
            meteor.MeteorModel.OnMeteorDestroyed += OnMeteorDestroyed;
        }

        private void OnMeteorDestroyed(bool byPlayer)
        {
            if (byPlayer)
            {
                _playerModel.AddScorePoints(1);
            }
        }

        private void OnEnemySpawned(EnemyInitializer enemy)
        {
            enemy.RocketModel.OnRocketDestroyed += b => OnEnemyDestroyed(b, enemy.EnemyModel.Reward);
        }

        private void OnEnemyDestroyed(bool byPlayer, int reward)
        {
            if (byPlayer)
            {
                _playerModel.AddScorePoints(reward);
            }
        }
    }
}