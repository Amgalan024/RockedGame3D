using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerMovements : RocketMovement
{
    private Rigidbody Rigidbody;
    private float verticalInput;
    private float horizontalInput;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    public override void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Rigidbody.velocity = new Vector3(Rocket.Speed * horizontalInput, Rocket.Speed * verticalInput);
    }
}
