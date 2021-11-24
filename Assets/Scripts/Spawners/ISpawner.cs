using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

interface ISpawner<T> where T: MonoBehaviour
{
    float SpawnTimer { set; get; }
    Pool<T> Pool { set; get; }
    void Spawn();
    void CountDown();
}
