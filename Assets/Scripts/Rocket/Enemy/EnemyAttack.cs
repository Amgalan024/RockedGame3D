using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class EnemyAttack : MonoBehaviour, IRocket, IGameObjectComponent<Rocket>
{
    public Rocket Rocket { get; set; }
    public GameObject PlayerGameObject { set; get; }
    private IRocketAttack rocketAttack;
    private float timer = 0;
    private Quaternion aimRotation;
    private void Awake()
    {
        rocketAttack = GetComponentInChildren<IRocketAttack>();
        PlayerGameObject = FindObjectOfType<PlayerMovements>().gameObject;
    }
    private void FixedUpdate()
    {
        Attack();
    }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
    }
    private void Attack()
    {
        if (timer <= 0)
        {
            AimAtPlayer();
            rocketAttack.Attack(aimRotation);
            timer = Rocket.AttackSpeed;
        }
        if (timer >= 0)
        {
            timer = timer - Time.fixedDeltaTime;
        }
    }
    private void AimAtPlayer()
    {
        float a = transform.position.y - PlayerGameObject.transform.position.y;
        float b = Vector2.Distance(transform.position, PlayerGameObject.transform.position);
        float angle = Mathf.Acos(a / b) * Mathf.Rad2Deg;
        if (transform.position.x > PlayerGameObject.transform.position.x)
        {
            aimRotation = Quaternion.Euler(0, 0, -angle);
        }
        else
        {
            aimRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
