using Core.InteractionHandle.Visitors;
using UnityEngine;

namespace Items
{
    public class ItemInteractionHandler : MonoBehaviour
    {
        public ItemBase Item { get; private set; }

        private void Awake()
        {
            Item = GetComponent<ItemBase>();
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