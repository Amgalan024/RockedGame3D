using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MeteorBuilder : MonoBehaviour, IMeteor
{
    [SerializeField] private int healthPoints;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private int reward;

    public Meteor Meteor { set; get; } 
    private void Awake()
    {
        InitializeMeteor();
    }
    public void InitializeMeteor()
    {
        Meteor = new Meteor(healthPoints, damage, speed, reward);
        foreach (var component in GetComponents<IGameObjectComponent<Meteor>>())
        {
            component.InitializeComponent(Meteor);
        }
        foreach (var component in GetComponentsInChildren<IGameObjectComponent<Meteor>>())
        {
            component.InitializeComponent(Meteor);
        }
    }
}
