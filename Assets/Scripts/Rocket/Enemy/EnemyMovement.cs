using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyMovement : RocketMovement
{
    [SerializeField] private bool moveRight;
    [SerializeField] private float chaseDistance;
    public RocketBuilder PlayerRocket { set; get; }
    private Rigidbody eRigidbody;
    private Quaternion aimRotation;
    private void Awake()
    {
        eRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<SideBorder>())
        {
            moveRight = !moveRight;
        }
    }
    public override void Movement()
    {
        AimAtPlayer();
        if (Vector3.Distance(transform.position,PlayerRocket.transform.position) >= chaseDistance)
        {
            eRigidbody.velocity = new Vector2(0, -Rocket.Speed);
        }
        else
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
    }
    private void AimAtPlayer()
    {
        float a = transform.position.y - PlayerRocket.transform.position.y;
        float b = Vector2.Distance(transform.position, PlayerRocket.transform.position);
        float angle = Mathf.Acos(a / b) * Mathf.Rad2Deg;
        if (transform.position.x > PlayerRocket.transform.position.x)
        {
            aimRotation = Quaternion.Euler(0, 0, -angle);
        }
        else
        {
            aimRotation = Quaternion.Euler(0, 0, angle);
        }
        transform.rotation = aimRotation;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y-chaseDistance));
    }
}
