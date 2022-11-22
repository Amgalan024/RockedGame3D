using Core.InteractionHandle.Visitors;
using Items.InteractionHandlers;
using UnityEngine;

namespace Items
{
    public class ItemInteractionHandler : MonoBehaviour, ITriggerEnterVisitor
    {
        public IInteractionVisitor TriggerEnterVisitor { get; set; }

        private void Awake()
        {
            var item = GetComponent<ItemBase>();

            TriggerEnterVisitor = new ItemTriggerEnterVisitor(item);
        }

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
    }
}