using System;
using Core;
using Rocket.Components.Player.InteractionHandlers;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerInteractionHandler : MonoBehaviour, IPlayerComponent, ICollisionEnterHandler,
        ITriggerEnterHandler
    {
        public PlayerModel PlayerModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; set; }
        public IInteractionVisitor TriggerEnterVisitor { get; set; }

        public void InitializeComponent(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
            CollisionEnterVisitor = new PlayerCollisionEnterVisitor(PlayerModel);
            TriggerEnterVisitor = new PlayerTriggerEnterVisitor(PlayerModel);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionEnterHandler = collision.gameObject.GetComponent<ICollisionEnterHandler>();

            collisionEnterHandler.CollisionEnterVisitor.Visit(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var triggerEnterHandler = other.gameObject.GetComponent<ITriggerEnterHandler>();

            triggerEnterHandler.TriggerEnterVisitor.Visit(this);
        }
    }
}