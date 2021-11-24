using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RocketGun : MonoBehaviour,IGameObjectComponent<Rocket>, IRocket
{
    [SerializeField] private RocketProjectileMovement projectilePrefab;
    private Pool<RocketProjectileMovement> projectilePrefabPool;
    public Rocket Rocket { get; set; }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
        int poolCount = 10;
        projectilePrefabPool = new Pool<RocketProjectileMovement>(projectilePrefab, poolCount, transform);
        projectilePrefabPool.AutoExpand = true;
        foreach (var projectile in projectilePrefabPool.PrefabsPool)
        {
            projectile.InitializeComponent(Rocket);
        }
    }
    public void ShootProjectile()
    {
        projectilePrefabPool.GetFreeElement();
    }
    public void ShootProjectile(Quaternion rotation)
    {
        projectilePrefabPool.GetFreeElement().transform.rotation = rotation;
    }
}
