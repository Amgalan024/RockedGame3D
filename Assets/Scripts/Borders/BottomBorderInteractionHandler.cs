using Core;
using UnityEngine;

namespace Borders
{
    public class BottomBorderInteractionHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var triggerEnterHandler = other.GetComponent<ITriggerEnterHandler>();

            triggerEnterHandler.TriggerEnterVisitor.Visit(this);
        }
    }
}