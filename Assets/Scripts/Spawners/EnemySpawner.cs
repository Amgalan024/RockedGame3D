using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class EnemySpawner : MonoBehaviour, ISpawner<RocketBuilder>
{
    [SerializeField] private float spawnfrequency;
    [SerializeField] private RocketBuilder enemyPrefab;
    [SerializeField] private GameObject playerGameObject;
    public float SpawnTimer { get; set; }
    public Pool<RocketBuilder> Pool { get; set; }
    private void Start()
    {
        Pool = new Pool<RocketBuilder>(enemyPrefab, 10, transform);
        foreach (var enemy in Pool.PrefabsPool)
        {
            enemy.GetComponent<EnemyAttack>().PlayerGameObject = playerGameObject;
            enemy.GetComponent<EnemyMovement>().PlayerGameObject = playerGameObject;
        }
        Pool.AutoExpand = true;
    }
    private void Update()
    {
        Spawn();
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
