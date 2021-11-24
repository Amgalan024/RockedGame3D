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
    public float SpawnTimer { get; set; }
    public Pool<MeteorBuilder> Pool { get ; set ; }
    private void Start()
    {
        Pool = new Pool<MeteorBuilder>(meteorPrefab,10, transform);
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
