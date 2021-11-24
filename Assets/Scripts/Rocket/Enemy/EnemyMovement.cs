using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyMovement : RocketMovement
{
    public GameObject PlayerGameObject { set; get; }
    private Rigidbody eRigidbody;
    private Quaternion aimRotation;
    [SerializeField] private bool moveRight;
    private void Awake()
    {
        eRigidbody = GetComponent<Rigidbody>();
        PlayerGameObject = FindObjectOfType<PlayerMovements>().gameObject;
    }
    private void FixedUpdate()
    {
        Movement();
        AimAtPlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SideBorder>())
        {
            moveRight = !moveRight;
        }
    }
    public override void Movement()
    {
        if (moveRight)
        {
            eRigidbody.velocity = new Vector2(Rocket.Speed, 0);
        }
        else
        {
            eRigidbody.velocity = new Vector2(-Rocket.Speed, 0);
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
        transform.rotation = aimRotation;
    }
}
