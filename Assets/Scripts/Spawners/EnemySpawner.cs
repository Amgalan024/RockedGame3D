using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class EnemySpawner : MonoBehaviour, ISpawner<RocketBuilder>
{
    [SerializeField] private RocketBuilder enemyPrefab;
    [SerializeField] private float spawnfrequency;
    [SerializeField] private int maxEnemiesCount;
    [SerializeField] private int currentEnemiesCount = 0;
    public Pool<RocketBuilder> Pool { get; set; }
    public RocketBuilder PlayerRocket { set; get; }
    public float SpawnTimer { get; set; }
    private void Update()
    {
        Spawn();
    }
    public void InitializeSpawner(RocketBuilder playerRocket)
    {
        this.PlayerRocket = playerRocket;
        Pool = new Pool<RocketBuilder>(enemyPrefab, maxEnemiesCount, transform);
        foreach (var enemy in Pool.PrefabsPool)
        {
            enemy.InitializeRocket();
            enemy.GetComponent<EnemyAttack>().PlayerRocket = PlayerRocket;
            enemy.GetComponent<EnemyMovement>().PlayerRocket = PlayerRocket;
            enemy.Rocket.OnRocketDestroyed += OnEnemyDestroyed;
        }
        Pool.AutoExpand = true;
        Pool.OnPoolExpanded += OnPoolExpanded;
    }

    private void OnPoolExpanded(RocketBuilder enemy)
    {
        enemy.InitializeRocket();
        enemy.GetComponent<EnemyAttack>().PlayerRocket = PlayerRocket;
        enemy.GetComponent<EnemyMovement>().PlayerRocket = PlayerRocket;
        enemy.Rocket.OnRocketDestroyed += OnEnemyDestroyed;
    }
    private void OnEnemyDestroyed()
    {
        SpawnTimer = spawnfrequency;
        currentEnemiesCount -= 1;
        Debug.Log($"currentEnemiesCount = {currentEnemiesCount}");
    }

    public void Spawn()
    {
        if ((SpawnTimer <= 0) && (currentEnemiesCount < maxEnemiesCount))
        {
            SpawnTimer = spawnfrequency;
            Pool.GetFreeElement();
            currentEnemiesCount++;
        }
        CountDown();
    }
    public void CountDown()
    {
        if (SpawnTimer >= 0)
        {
            SpawnTimer = SpawnTimer - Time.deltaTime;
        }
    }
}
