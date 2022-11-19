using Core;
using Meteor.Components;
using Meteor.Models;
using Rocket.Components.Player;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components
{
    public class RocketProjectileMovement : MonoBehaviour, IRocketComponent, IInteractable<RocketModel>,
        IInteractable<MeteorModel>
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        public RocketModel RocketModel { get; set; }

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidbody.velocity = transform.up * _speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<MeteorInteractionHandler>())
            {
                gameObject.SetActive(false);
            }

            if (collision.gameObject.GetComponent<RocketInitializer>())
            {
                gameObject.SetActive(false);
            }
        }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
            _speed = rocketModel.ProjectileSpeed;
            _damage = rocketModel.Damage;
        }

        public void Interact(RocketModel rocketModel)
        {
            rocketModel.TakeDamage(_damage);
        }

        public void Interact(MeteorModel meteorModel)
        {
            meteorModel.TakeDamage(_damage);
        }
    }
}