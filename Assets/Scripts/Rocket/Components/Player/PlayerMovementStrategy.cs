using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerMovementStrategy : MonoBehaviour, IRocketMovementStrategy
    {
        public RocketModel RocketModel { get; set; }

        private Rigidbody _rigidbody;
        private float _verticalInput;
        private float _horizontalInput;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        public void InitializeComponent(RocketModel component)
        {
            RocketModel = component;
        }

        public void Movement()
        {
            _verticalInput = Input.GetAxis("Vertical");
            _horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector3(RocketModel.Speed * _horizontalInput, RocketModel.Speed * _verticalInput);
        }
    }
}