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
        [SerializeField] private EnemySpawner[] _enemySpawners;
        [SerializeField] private ItemSpawner[] _itemSpawners;
        [SerializeField] private MeteorSpawner[] _meteorSpawners;
        [SerializeField] private PlayerStatsPanel _playerStatsPanel;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        private PlayerInitializer _playerInitializer;

        private void Start()
        {
            _playerInitializer =
                Instantiate(_playerRocketPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);

            _playerInitializer.InitializePlayer(_playerProjectileContainer);

            _playerStatsPanel.InitializeComponent(_playerInitializer.PlayerModel);

            InitializeSpawners();

            _cinemachineVirtualCamera.Follow = _playerInitializer.transform;

            OnPlayerModelInitialized?.Invoke(_playerInitializer.PlayerModel);
        }

        private void InitializeSpawners()
        {
            foreach (var spawner in _enemySpawners)
            {
                spawner.Initialize();
            }

            foreach (var spawner in _itemSpawners)
            {
                spawner.Initialize();
            }

            foreach (var spawner in _meteorSpawners)
            {
                spawner.Initialize();
            }
        }
    }
}