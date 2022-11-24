using Core.InteractionHandle.Visitors;
using Meteor.Components.InteractionVisitors;
using Meteor.Models;
using UnityEngine;

namespace Meteor.Components
{
    public class MeteorInteractionHandler : MonoBehaviour, IMeteorComponent, ICollisionEnterVisitor
    {
        public MeteorModel MeteorModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; set; }

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

        public void InitializeComponent(MeteorModel meteorModel)
        {
            MeteorModel = meteorModel;
            CollisionEnterVisitor = new MeteorCollisionEnterVisitor(MeteorModel);
        }
    }
}