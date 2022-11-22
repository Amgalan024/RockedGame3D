using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerMovementStrategy : MonoBehaviour, IRocketMovementStrategy, IPlayerComponent
    {
        public PlayerModel PlayerModel { get; set; }

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

        public void InitializeComponent(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        public void Movement()
        {
            _verticalInput = Input.GetAxis("Vertical");
            _horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector3(PlayerModel.RocketModel.Speed * _horizontalInput,
                PlayerModel.RocketModel.Speed * _verticalInput);
        }
    }
}