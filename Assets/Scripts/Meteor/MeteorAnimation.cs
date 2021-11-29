using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MeteorAnimation : MonoBehaviour, IMeteor, IGameObjectComponent<Meteor>
{
    private Animator animator;
    public Meteor Meteor { get; set; }
    private ParticleSystem[] explode;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        explode = GetComponentsInChildren<ParticleSystem>();
    }
    private void OnEnable()
    {
        animator.SetBool("IsDestroyed", false);
    }
    public void InitializeComponent(Meteor meteor)
    {
        Meteor = meteor;
        Meteor.OnMeteorDestroyed += OnMeteorDestroyed;
    }
    private void OnMeteorDestroyed()
    {
        animator.SetBool("IsDestroyed", true);
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
