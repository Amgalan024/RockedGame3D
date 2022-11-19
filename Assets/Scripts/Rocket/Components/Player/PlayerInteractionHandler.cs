using Core;
using Meteor.Models;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerInteractionHandler : MonoBehaviour, IPlayerComponent, IInteractable<MeteorModel>
    {
        public PlayerModel PlayerModel { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            var rocketInteractable = collision.gameObject.GetComponent<IInteractable<RocketModel>>();
            rocketInteractable.Interact(PlayerModel.RocketModel);

            var interactable = collision.gameObject.GetComponent<IInteractable<PlayerModel>>();
            interactable?.Interact(PlayerModel);
        }

        private void OnTriggerEnter(Collider other)
        {
            var rocketInteractable = other.gameObject.GetComponent<IInteractable<RocketModel>>();
            rocketInteractable.Interact(PlayerModel.RocketModel);

            var interactable = other.gameObject.GetComponent<IInteractable<PlayerModel>>();
            interactable?.Interact(PlayerModel);
        }

        public void InitializeComponent(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        private void OnPlayerDied(bool byPlayer)
        {
            Debug.Log($"Player Died");
            gameObject.SetActive(false);
        }

        public void Interact(MeteorModel meteorModel)
        {
            meteorModel.DestroyMeteor();
        }
    }
}