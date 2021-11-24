using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class MeteorSpawner : MonoBehaviour, ISpawner<MeteorBuilder>
{
    [SerializeField] private MeteorBuilder meteorPrefab;
    [SerializeField] private float spawnfrequency;
    [SerializeField] private int poolCount;
    public Pool<MeteorBuilder> Pool { get ; set ; }
    public RocketBuilder PlayerRocket { set; get; }
    public float SpawnTimer { get; set; }
    private void Update()
    {
        Spawn();
    }
    public void InitializeSpawner(RocketBuilder playerRocket)
    {
        Pool = new Pool<MeteorBuilder>(meteorPrefab, poolCount, transform);
        Pool.AutoExpand = true;
    }
    public void Spawn()
    {
        if (SpawnTimer <= 0)
        {
            SpawnTimer = spawnfrequency;
            Pool.GetFreeElement().InitializeMeteor();
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
