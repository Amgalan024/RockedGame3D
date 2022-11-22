using System;
using Cinemachine;
using Rocket.Components.Player;
using Rocket.Models;
using Spawners;
using UnityEngine;

namespace Controllers.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action<PlayerModel> OnPlayerModelInitialized;

        [SerializeField] private PlayerInitializer _playerRocketPrefab;
        [SerializeField] private Transform _playerProjectileContainer;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private MeteorSpawner _meteorSpawner;
        [SerializeField] private ItemSpawner _itemSpawner;
        [SerializeField] private PlayerStatsPanel _playerStatsPanel;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        private PlayerInitializer _playerInitializer;

        private void Start()
        {
            _playerInitializer =
                Instantiate(_playerRocketPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);

            _playerInitializer.InitializePlayer(_playerProjectileContainer);

            _playerStatsPanel.InitializeComponent(_playerInitializer.PlayerModel);

            _enemySpawner.InitializeSpawner(_playerInitializer.PlayerModel.RocketModel.RocketTransform);
            _meteorSpawner.InitializeSpawner();
            _itemSpawner.InitializeSpawner();

            _cinemachineVirtualCamera.Follow = _playerInitializer.transform;

            OnPlayerModelInitialized?.Invoke(_playerInitializer.PlayerModel);
        }
    }
}