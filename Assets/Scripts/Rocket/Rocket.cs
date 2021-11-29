using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class Rocket
{
    public event Action<Rocket> OnRocketDestroyed;
    public event Action<int> OnHealthPointsChanged;
    public event Action<int> OnEnergyPointsChanged;
    public event Action<int> OnDamageChanged;
    public event Action<int> OnPlayerScoreChanged;
    public event Action<float> OnSpeedChanged;
    public int PlayerScore { private set; get; }
    public int HealthPoint { private set; get; }
    public int MaxHealthPoint { private set; get; }
    public int EnergyPoint { private set; get; }
    public int MaxEnergyPoint { private set; get; }
    public int Damage { private set; get; }
    public float Speed{ private set; get; }
    public float ProjectileSpeed { private set; get; }
    public float AttackSpeed { private set; get; }
    public int Reward { private set; get; }
    public Rocket(int healthPoints,int energyPoints, int damage, float speed,float projectileSpeed, float attackSpeed, int reward)
    {
        PlayerScore = 0;
        this.HealthPoint = healthPoints;
        this.MaxHealthPoint = healthPoints;
        this.EnergyPoint = energyPoints;
        this.MaxEnergyPoint = energyPoints;
        this.Damage = damage;
        this.Speed = speed;
        this.ProjectileSpeed = projectileSpeed;
        this.AttackSpeed = attackSpeed;
        this.Reward = reward;
    }
    public void TakeDamage(int damage)
    {
        this.HealthPoint -= damage;
        OnHealthPointsChanged?.Invoke(this.HealthPoint);
        if (HealthPoint <= 0)
        {
            HealthPoint = 0;
            OnRocketDestroyed?.Invoke(this);
        }
    }
    public void RestoreEP(int heal)
    {
        this.EnergyPoint += heal;
        OnEnergyPointsChanged?.Invoke(this.EnergyPoint);
    }
    public void RestoreHP(int heal)
    {
        this.HealthPoint += heal;
        OnHealthPointsChanged?.Invoke(this.HealthPoint);
    }
    public void DestroyRocket()
    {
        this.HealthPoint = 0;
        OnHealthPointsChanged?.Invoke(this.HealthPoint);
        OnRocketDestroyed?.Invoke(this);
    }
    public void AddScorePoints(int points)
    {
        this.PlayerScore += points;
        OnPlayerScoreChanged?.Invoke(this.PlayerScore);
    }
    public void SubtractScorePoints(int points)
    {
        this.PlayerScore -= points;
        OnPlayerScoreChanged?.Invoke(this.PlayerScore);
    }
    public void MultiplyDamage(int multiplier)
    {
        this.Damage =this.Damage * multiplier;
        OnDamageChanged?.Invoke(this.Damage);
    }
    public void DivideDamage(int divider)
    {
        this.Damage = this.Damage / divider;
        OnDamageChanged?.Invoke(this.Damage);
    }
}
