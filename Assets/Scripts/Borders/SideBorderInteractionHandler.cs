using Core.InteractionHandle.Visitors;
using UnityEngine;

namespace Borders
{
    public class SideBorderInteractionHandler : MonoBehaviour
    {
        [SerializeField] private SideBorderInteractionHandler _oppositeSideBorder;
        [SerializeField] private float _offset;

        public float Offset => _offset;
        public SideBorderInteractionHandler OppositeSideBorder => _oppositeSideBorder;

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