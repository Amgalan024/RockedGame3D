using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Projectile
{
    public class ProjectileMovement : MonoBehaviour, IRocketComponent
    {
        public RocketModel RocketModel { get; set; }

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidbody.velocity = transform.up * RocketModel.ProjectileSpeed;
        }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
        }
    }
}