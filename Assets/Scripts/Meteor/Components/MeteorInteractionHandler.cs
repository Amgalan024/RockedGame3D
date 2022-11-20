using System;
using Core;
using Meteor.Components.InteractionVisitors;
using Meteor.Models;
using Rocket.Models;
using UnityEngine;

namespace Meteor.Components
{
    public class MeteorInteractionHandler : MonoBehaviour, IMeteorComponent, ICollisionEnterHandler,
        ITriggerEnterHandler
    {
        public MeteorModel MeteorModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; set; }
        public IInteractionVisitor TriggerEnterVisitor { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionEnterHandler = collision.gameObject.GetComponent<ICollisionEnterHandler>();

            collisionEnterHandler.CollisionEnterVisitor.Visit(this);
        }

        public void InitializeComponent(MeteorModel meteorModel)
        {
            MeteorModel = meteorModel;
            CollisionEnterVisitor = new MeteorCollisionEnterVisitor(MeteorModel);
            TriggerEnterVisitor = new MeteorTriggerEnterVisitor(MeteorModel);
        }

        public void Interact(PlayerModel playerModel)
        {
            playerModel.RocketModel.TakeDamage(MeteorModel.Damage);
        }
    }
}