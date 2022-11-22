using Core.InteractionHandle.Visitors;
using Rocket.Components.Player.InteractionHandlers;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerInteractionHandler : MonoBehaviour, IPlayerComponent, ICollisionEnterVisitor,
        ITriggerEnterVisitor
    {
        public PlayerModel PlayerModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; set; }
        public IInteractionVisitor TriggerEnterVisitor { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionEnterHandler = collision.gameObject.GetComponent<ICollisionEnterVisitor>();

            collisionEnterHandler?.CollisionEnterVisitor.Visit(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var triggerEnterHandler = other.gameObject.GetComponent<ITriggerEnterVisitor>();

            triggerEnterHandler?.TriggerEnterVisitor.Visit(this);
        }

        public void InitializeComponent(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
            CollisionEnterVisitor = new PlayerCollisionEnterVisitor(PlayerModel);
            TriggerEnterVisitor = new PlayerTriggerEnterVisitor(PlayerModel);
        }
    }
}