using System.Collections;
using Core;
using Cysharp.Threading.Tasks;
using Rocket.Components.Player;
using Rocket.Models;
using UnityEngine;

namespace Items
{
    public abstract class InteractableItem : MonoBehaviour, IInteractable<RocketModel>
    {
        [SerializeField] private float fallSpeed;
        private Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(0, -fallSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerInteractionHandler>())
            {
                gameObject.SetActive(false);
            }
        }

        public void Interact(RocketModel rocketModel)
        {
            Buff(rocketModel);
        }

        public abstract UniTask Buff(RocketModel rocketModel);
    }
}