using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IGameObjectComponent<Rocket>, IRocket
{
    private IRocketAttack rocketAttack;
    public Rocket Rocket { get; set; }
    private void Awake()
    {
        rocketAttack = GetComponentInChildren<IRocketAttack>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rocketAttack.Attack();
        }
    }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
    }
}
