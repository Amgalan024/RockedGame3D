using System;
using UnityEngine;

namespace Rocket.Models
{
    public class RocketModel
    {
        public event Action<bool> OnRocketDestroyed;
        public event Action<int> OnHealthPointsChanged;
        public event Action<int> OnEnergyPointsChanged;
        public event Action<int> OnDamageChanged;
        public event Action<int> OnAmmoChanged;
        public event Action<float> OnSpeedChanged;

        public int HealthPoint { private set; get; }
        public int MaxHealthPoint { private set; get; }
        public int EnergyPoint { private set; get; }
        public int MaxEnergyPoint { private set; get; }
        public int Damage { private set; get; }
        public float Speed { private set; get; }
        public float ProjectileSpeed { private set; get; }
        public float AttackSpeed { private set; get; }
        public int Ammo { private set; get; }
        public Transform RocketTransform { get; }
        public Transform ProjectilesContainer { get; }

        public RocketModel(int healthPoints, int energyPoints, int damage, float speed, float projectileSpeed,
            float attackSpeed, int startAmmo, Transform rocketTransform, Transform projectilesContainer)
        {
            HealthPoint = healthPoints;
            MaxHealthPoint = healthPoints;
            EnergyPoint = energyPoints;
            MaxEnergyPoint = energyPoints;
            Damage = damage;
            Speed = speed;
            ProjectileSpeed = projectileSpeed;
            AttackSpeed = attackSpeed;
            Ammo = startAmmo;
            RocketTransform = rocketTransform;
            ProjectilesContainer = projectilesContainer;
        }

        public void TakeDamage(int damage, bool byPlayer = true)
        {
            HealthPoint -= damage;

            OnHealthPointsChanged?.Invoke(HealthPoint);

            if (HealthPoint <= 0)
            {
                HealthPoint = 0;
                OnRocketDestroyed?.Invoke(byPlayer);
            }
        }

        public void RestoreEP(int heal)
        {
            EnergyPoint += heal;
            OnEnergyPointsChanged?.Invoke(EnergyPoint);
        }

        public void RestoreHP(int heal)
        {
            HealthPoint += heal;
            OnHealthPointsChanged?.Invoke(HealthPoint);
        }

        public void DestroyRocket()
        {
            TakeDamage(HealthPoint, false);
        }

        public void MultiplyDamage(int multiplier)
        {
            Damage *= multiplier;
            OnDamageChanged?.Invoke(Damage);
        }

        public void DivideDamage(int divider)
        {
            Damage /= divider;
            OnDamageChanged?.Invoke(Damage);
        }

        public void AddAmmo(int ammo)
        {
            Ammo += ammo;
            OnAmmoChanged?.Invoke(Ammo);
        }

        public void WasteAmmo()
        {
            Ammo -= 1;
            OnAmmoChanged?.Invoke(Ammo);
        }
    }
}