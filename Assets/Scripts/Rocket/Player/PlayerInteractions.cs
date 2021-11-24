using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IGameObjectComponent<Rocket>, IRocket
{
    private CapsuleCollider capsuleCollider;
    public Rocket Rocket { get; set; }
    //private Animator
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
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
        Rocket.OnPlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        Debug.Log($"Player Died");
        Destroy(gameObject);
    }
}
