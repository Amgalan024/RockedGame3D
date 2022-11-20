using System;
using Core;
using Items.InteractionHandlers;
using UnityEngine;

namespace Items
{
    public class ItemInteractionHandler : MonoBehaviour, ITriggerEnterHandler
    {
        public IInteractionVisitor TriggerEnterVisitor { get; set; }

        private void Awake()
        {
            var item = GetComponent<ItemBase>();

            TriggerEnterVisitor = new ItemTriggerEnterVisitor(item);
        }

        private void OnTriggerEnter(Collider other)
        {
            var triggerEnterHandler = other.GetComponent<ITriggerEnterHandler>();

            triggerEnterHandler.TriggerEnterVisitor.Visit(this);
        }
    }
}