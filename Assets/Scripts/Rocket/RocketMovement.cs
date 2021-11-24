using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

abstract public class RocketMovement : MonoBehaviour, IGameObjectComponent<Rocket>,IRocket
{
    public Rocket Rocket { get; set; }
    public abstract void Movement();
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
    }
}
