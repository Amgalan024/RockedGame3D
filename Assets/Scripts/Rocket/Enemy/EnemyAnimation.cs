using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour,IRocket, IGameObjectComponent<Rocket>
{
    private Animator animator;
    public Rocket Rocket { get; set; }
    private ParticleSystem[] explode;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        animator.SetBool("IsDestroyed", false);
    }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
        Rocket.OnRocketDestroyed += OnEnemyDied;
        explode = GetComponentsInChildren<ParticleSystem>();
    }
    private void OnEnemyDied(Rocket rocket)
    {
        animator.SetBool("IsDestroyed", true);
    }
    #region AnimatorEvents
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
    public void PlayExplodeAnim()
    {
        for (int i = 0; i < explode.Length; i++)
        {
            explode[i].Play();
        }
    }
    #endregion
}
