using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RocketBuilder : MonoBehaviour,IRocket
{
    [SerializeField] private int healthPoints;
    [SerializeField] private int energyPoints;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int reward;

    public Rocket Rocket { set; get; }
    private void Awake()
    {
        InitializeRocket();
    }
    public void InitializeRocket()
    {
        Rocket = new Rocket(healthPoints, energyPoints, damage, speed, projectileSpeed, attackSpeed, reward);
        foreach (var component in GetComponents<IGameObjectComponent<Rocket>>())
        {
            component.InitializeComponent(this.Rocket);
        }
        foreach (var component in GetComponentsInChildren<IGameObjectComponent<Rocket>>())
        {
            component.InitializeComponent(this.Rocket);
        }
    }
}
