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
    [SerializeField] private int poolCount;
    public Pool<RocketBuilder> Pool { get; set; }
    public RocketBuilder PlayerRocket { set; get; }
    public float SpawnTimer { get; set; }
    private void Update()
    {
        Spawn();
    }
    public void InitializeSpawner(RocketBuilder playerRocket)
    {
        Pool = new Pool<RocketBuilder>(enemyPrefab, poolCount, transform);
        foreach (var enemy in Pool.PrefabsPool)
        {
            enemy.GetComponent<EnemyAttack>().PlayerRocket = playerRocket;
            enemy.GetComponent<EnemyMovement>().PlayerRocket = playerRocket;
        }
        Pool.AutoExpand = true;
    }
    public void Spawn()
    {
        if (SpawnTimer <= 0)
        {
            SpawnTimer = spawnfrequency;
            Pool.GetFreeElement().InitializeRocket();
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
