using System;

namespace Meteor.Models
{
    public class MeteorModel
    {
        public event Action<bool> OnMeteorDestroyed;
        public event Action<int> OnHealthPointsChanged;
        public int HealthPoints { private set; get; }
        public int Damage { private set; get; }
        public float Speed { private set; get; }
        public int Reward { private set; get; }

        public MeteorModel(int healthPoints, int damage, float speed, int reward)
        {
            HealthPoints = healthPoints;
            Damage = damage;
            Speed = speed;
            Reward = reward;
        }

        public void TakeDamage(int damage, bool byPlayer = true)
        {
            HealthPoints -= damage;

            OnHealthPointsChanged?.Invoke(HealthPoints);

            if (HealthPoints <= 0)
            {
                OnMeteorDestroyed?.Invoke(byPlayer);
            }
        }

        public void DestroyMeteor()
        {
            TakeDamage(HealthPoints, false);
        }
    }
}