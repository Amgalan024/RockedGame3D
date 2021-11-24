using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rocket
{
    public event Action OnPlayerDied;
    public event Action<int> OnHealthPointsChanged;
    public event Action<int> OnEnergyPointsChanged;
    public event Action<int> OnDamageChanged;
    public event Action<float> OnSpeedChanged;
    
    public int HealthPoint { private set; get; }
    public int EnergyPoint { private set; get; }
    public int Damage { private set; get; }
    public float Speed{ private set; get; }
    public float ProjectileSpeed { private set; get; }
    public float AttackSpeed { private set; get; }


    public Rocket(int healthPoints,int energyPoints, int damage, float speed,float projectileSpeed, float attackSpeed)
    {
        this.HealthPoint = healthPoints;
        this.EnergyPoint = energyPoints;
        this.Damage = damage;
        this.Speed = speed;
        this.ProjectileSpeed = projectileSpeed;
        this.AttackSpeed = attackSpeed;
    }
    public void TakeDamage(int damage)
    {
        this.HealthPoint -= damage;
        OnHealthPointsChanged?.Invoke(this.HealthPoint);
        if (HealthPoint <= 0)
        {
            OnPlayerDied?.Invoke();
        }
    }
    public void RestoreHP(int heal)
    {
        this.HealthPoint += heal;
        OnHealthPointsChanged?.Invoke(this.HealthPoint);
    }

}
