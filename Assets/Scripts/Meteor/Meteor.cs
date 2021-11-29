using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Meteor
{
    public event Action OnMeteorDestroyed;
    public event Action<int> OnHealthPointsChanged;
    public int HealthPoints { private set; get; }
    public int Damage { private set; get; }
    public float Speed { private set; get; }
    public int Reward { private set; get; }
    public Meteor(int healthPoints, int damage, float speed, int reward)
    {
        this.HealthPoints = healthPoints;
        this.Damage = damage;
        this.Speed = speed;
        this.Reward = reward;
    }
    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
        OnHealthPointsChanged?.Invoke(this.HealthPoints);
        if (HealthPoints <= 0)
        {
            OnMeteorDestroyed?.Invoke();
        }
    }
    public void DestroyMeteor()
    {
        this.HealthPoints = 0;
        OnHealthPointsChanged?.Invoke(this.HealthPoints);
        OnMeteorDestroyed?.Invoke();
    }
}
