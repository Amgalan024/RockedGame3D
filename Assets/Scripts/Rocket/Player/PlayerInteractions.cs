using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IGameObjectComponent<Rocket>, IRocket
{
    public Rocket Rocket { get; set; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeteorMovement>())
        {
            Rocket.TakeDamage(collision.gameObject.GetComponent<MeteorMovement>().Meteor.Damage);
        }
        if (collision.gameObject.GetComponent<RocketProjectileMovement>())
        {
            Rocket.TakeDamage(collision.gameObject.GetComponent<RocketProjectileMovement>().GetDamage());
        }
    }
    public void InitializeComponent(Rocket rocket)
    {
        Rocket = rocket;
        Rocket.OnRocketDestroyed += OnPlayerDied;
    }
    private void OnPlayerDied(Rocket player)
    {
        Debug.Log($"Player Died");
        gameObject.SetActive(false);
    }
}
