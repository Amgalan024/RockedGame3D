using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EnemyInteractions : MonoBehaviour, IRocket, IGameObjectComponent<Rocket>
{
    public Rocket Rocket { get; set; }
    private CapsuleCollider capsuleCollider;
    private Animator animator;
    private ParticleSystem[] explode;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        explode = GetComponentsInChildren<ParticleSystem>();
    }
    private void OnEnable()
    {
        animator.SetBool("IsDestroyed",false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RocketProjectileMovement>())
        {
            Rocket.TakeDamage(collision.gameObject.GetComponent<RocketProjectileMovement>().GetDamage());
        }
    }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
        Rocket.OnRocketDestroyed += OnEnemyDied;
    }
    private void OnEnemyDied()
    {
        Rocket.RestoreHP(Rocket.MaxHealthPoint);
        animator.SetBool("IsDestroyed",true);
    }
    public void PlayExplodeAnim()
    {
        for (int i = 0; i < explode.Length; i++)
        {
            explode[i].Play();
        }
    }
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
