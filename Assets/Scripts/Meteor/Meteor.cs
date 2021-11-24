using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Meteor
{
    public event Action OnMeteorDestroyed;
    public event Action<int> OnHealthPointsChanged;
    public int HealthPoits { private set; get; }
    public int Damage { private set; get; }
    public float Speed { private set; get; }
    public Meteor(int healthPoints, int damage, float speed)
    {
        this.HealthPoits = healthPoints;
        this.Damage = damage;
        this.Speed = speed;
    }
    public void TakeDamage(int damage)
    {
        HealthPoits -= damage;
        OnHealthPointsChanged?.Invoke(this.HealthPoits);
        if (HealthPoits <= 0)
        {
            OnMeteorDestroyed?.Invoke();
        }
    }
}
