using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Cinemachine;

public class MainSceneHandler : MonoBehaviour
{
    [SerializeField] private RocketBuilder playerRocketPrefab;
    [SerializeField] private Transform playerSpawnPoint;
   // [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private MeteorSpawner meteorSpawner;
    [SerializeField] private PlayerStatsPanel playerStatsPanel;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera; 
    private RocketBuilder playerRocket;
    private void Awake()
    {
        playerRocket = Instantiate(playerRocketPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        playerRocket.InitializeRocket();
        cinemachineVirtualCamera.Follow = playerRocket.transform;
        playerStatsPanel.InitializeComponent(playerRocket.Rocket);
       // enemySpawner.InitializeSpawner(playerRocket);
        meteorSpawner.InitializeSpawner(playerRocket);
    }
}
