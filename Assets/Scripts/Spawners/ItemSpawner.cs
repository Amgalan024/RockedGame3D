using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemSpawner :MonoBehaviour, ISpawner<BuffItem>
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private BuffItem itemPrefab;
    [SerializeField] private float spawnfrequency;
    [SerializeField] private int poolCount;
    [SerializeField] private int spawnChance;
    public RocketBuilder PlayerRocket { get; set; }
    public float SpawnTimer { get ; set ; }
    public Pool<BuffItem> Pool { get; set; }
    private void Update()
    {
        Spawn();
    }
    public void InitializeSpawner(RocketBuilder playerRocket)
    {
        this.PlayerRocket = playerRocket;
        Pool = new Pool<BuffItem>(itemPrefab, poolCount, transform);
        Pool.AutoExpand = true;
    }
    public void Spawn()
    {
        if (SpawnTimer <= 0)
        {
            int randomedChance = UnityEngine.Random.Range(0, 100);
            if (randomedChance <= spawnChance)
            {
                int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
                SpawnTimer = spawnfrequency;
                Pool.GetFreeElement(spawnPoints[spawnPointIndex].position);
            }
            else
            {
                SpawnTimer = spawnfrequency;
            }
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
