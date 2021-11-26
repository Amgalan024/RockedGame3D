using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MeteorInteractions : MonoBehaviour, IGameObjectComponent<Meteor>, IMeteor
{
    private ParticleSystem[] mParticleSystemArray;
    private SphereCollider sphereCollider;
    private Animator animator;
    public Meteor Meteor { get ; set ; }
    //private Animator
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
        mParticleSystemArray = GetComponentsInChildren<ParticleSystem>();
    }
    private void OnEnable()
    {
        animator.SetBool("IsDestroyed", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteractions>())
        {
            animator.SetBool("IsDestroyed", true);
        }
        if (collision.gameObject.GetComponent<RocketProjectileMovement>())
        {
            Meteor.TakeDamage(collision.gameObject.GetComponent<RocketProjectileMovement>().GetDamage());
        }
    }
    public void InitializeComponent(Meteor meteor)
    {
        this.Meteor = meteor;
        Meteor.OnMeteorDestroyed += OnMeteorDestroyed;
    }
    private void OnMeteorDestroyed()
    {
        animator.SetBool("IsDestroyed", true);
    }
    public void PlayExplodeAnim()
    {
        for (int i = 0; i < mParticleSystemArray.Length; i++)
        {
            mParticleSystemArray[i].Play();
        }
    }
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
