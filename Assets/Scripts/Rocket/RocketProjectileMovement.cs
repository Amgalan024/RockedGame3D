using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class RocketProjectileMovement : MonoBehaviour, IGameObjectComponent<Rocket>
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Rigidbody pRigidbody;
    private void Awake()
    {
        pRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        pRigidbody.velocity = transform.up * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeteorInteractions>())
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.GetComponent<RocketBuilder>())
        {
            gameObject.SetActive(false);
        }
    }
    public void InitializeComponent(Rocket rocket)
    {
        speed = rocket.ProjectileSpeed;
        damage = rocket.Damage;
    }
    public int GetDamage()
    {
        return damage;
    }
}
