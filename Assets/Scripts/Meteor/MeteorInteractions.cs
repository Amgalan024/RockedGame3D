using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MeteorInteractions : MonoBehaviour, IGameObjectComponent<Meteor>, IMeteor
{
    public Meteor Meteor { get ; set ; }
    public RocketBuilder PlayerRocket { set; get; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteractions>())
        {
            Meteor.DestroyMeteor();
        }
        if (collision.gameObject.GetComponent<RocketProjectileMovement>())
        {
            Meteor.TakeDamage(collision.gameObject.GetComponent<RocketProjectileMovement>().GetDamage());
            if (Meteor.HealthPoints <= 0)
            {
                PlayerRocket.Rocket.AddScorePoints(Meteor.Reward);
            }
        }
    }
    public void InitializeComponent(Meteor meteor)
    {
        this.Meteor = meteor;
    }
}
