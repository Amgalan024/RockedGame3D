using Rocket.Components.Projectile;
using Rocket.Models;
using UnityEngine;
using Utils;

namespace Rocket.Components
{
    public class RocketGun : MonoBehaviour, IRocketComponent
    {
        [SerializeField] private ProjectileInitializer _projectilePrefab;

        public RocketModel RocketModel { get; set; }

        private Pool<ProjectileInitializer> _projectilePrefabPool;

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;

            int poolCount = 10;

            _projectilePrefabPool =
                new Pool<ProjectileInitializer>(_projectilePrefab, poolCount, RocketModel.ProjectilesContainer)
                {
                    AutoExpand = true
                };
        }

        public void ShootProjectile()
        {
            if (RocketModel.Ammo > 0)
            {
                var projectile = _projectilePrefabPool.GetFreeElement();

                projectile.InitializeProjectile(RocketModel);

                projectile.transform.position = transform.position;

                RocketModel.WasteAmmo();
            }
            else
            {
                Debug.Log("Not Enough Ammo!");
            }
        }

        public void ShootProjectile(Quaternion rotation)
        {
            if (RocketModel.Ammo > 0)
            {
                var projectile = _projectilePrefabPool.GetFreeElement();

                projectile.InitializeProjectile(RocketModel);

                projectile.transform.rotation = rotation;

                projectile.transform.position = transform.position;

                RocketModel.WasteAmmo();
            }
            else
            {
                Debug.Log("Not Enough Ammo!");
            }
        }
    }
}