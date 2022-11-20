using Core;
using Rocket.Components.InteractionHandlers;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components
{
    public class RocketProjectileInteractionHandler : MonoBehaviour, IRocketComponent, ICollisionEnterHandler
    {
        [SerializeField] private GameObject _projectile;

        public RocketModel RocketModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; set; }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
            CollisionEnterVisitor = new RocketCollisionEnterVisitor(_projectile);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionEnterHandler = collision.gameObject.GetComponent<ICollisionEnterHandler>();

            collisionEnterHandler.CollisionEnterVisitor.Visit(this);
        }
    }
}