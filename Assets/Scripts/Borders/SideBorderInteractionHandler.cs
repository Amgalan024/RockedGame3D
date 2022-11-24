using Borders.InteractionVisitors;
using Core.InteractionHandle.Visitors;
using UnityEngine;

namespace Borders
{
    public class SideBorderInteractionHandler : MonoBehaviour, ITriggerEnterVisitor
    {
        [SerializeField] private SideBorderInteractionHandler _oppositeSideBorder;
        [SerializeField] private float _offset;

        public IInteractionVisitor TriggerEnterVisitor { get; private set; }

        private void Awake()
        {
            TriggerEnterVisitor = new SideBorderTriggerEnterVisitor(_offset, _oppositeSideBorder.transform);
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