using Rocket.Models;
using UnityEngine;
using Utils;

namespace Rocket.Components
{
    public class RocketGun : MonoBehaviour, IRocketComponent
    {
        [SerializeField] private RocketProjectileMovement _projectilePrefab;

        public RocketModel RocketModel { get; set; }

        private Pool<RocketProjectileMovement> _projectilePrefabPool;

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
            RocketModel.OnDamageChanged += OnRocketDamageChanged;

            int poolCount = 10;

            _projectilePrefabPool = new Pool<RocketProjectileMovement>(_projectilePrefab, poolCount, transform)
            {
                AutoExpand = true
            };

            foreach (var projectile in _projectilePrefabPool.PrefabsPool)
            {
                projectile.InitializeComponent(RocketModel);
            }
        }

        private void OnRocketDamageChanged(int damage)
        {
            foreach (var projectile in _projectilePrefabPool.PrefabsPool)
            {
                projectile.InitializeComponent(RocketModel);
            }
        }

        public void ShootProjectile()
        {
            if (RocketModel.Ammo > 0)
            {
                _projectilePrefabPool.GetFreeElement();
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
                _projectilePrefabPool.GetFreeElement().transform.rotation = rotation;
                RocketModel.WasteAmmo();
            }
            else
            {
                Debug.Log("Not Enough Ammo!");
            }
        }
    }
}