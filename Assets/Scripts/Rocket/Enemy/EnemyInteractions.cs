using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class EnemyInteractions : MonoBehaviour, IRocket, IGameObjectComponent<Rocket>
{
    public Rocket Rocket { get; set; }
    public RocketBuilder PlayerRocket { set; get; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RocketProjectileMovement>())
        {
            Rocket.TakeDamage(collision.gameObject.GetComponent<RocketProjectileMovement>().GetDamage());
            if (Rocket.HealthPoint <= 0)
            {
                PlayerRocket.Rocket.AddScorePoints(Rocket.Reward);
                Rocket.RestoreHP(Rocket.MaxHealthPoint);
            }
        }
    }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
    }
}
