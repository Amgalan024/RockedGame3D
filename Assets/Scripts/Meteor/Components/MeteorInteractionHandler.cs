using Core;
using Meteor.Models;
using Rocket.Components.Player;
using Rocket.Models;
using UnityEngine;

namespace Meteor.Components
{
    public class MeteorInteractionHandler : MonoBehaviour, IMeteorComponent, IInteractable<PlayerModel>
    {
        public MeteorModel MeteorModel { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            var interactable = collision.gameObject.GetComponent<IInteractable<MeteorModel>>();
            interactable?.Interact(MeteorModel);
        }

        public void InitializeComponent(MeteorModel meteorModel)
        {
            MeteorModel = meteorModel;
        }

        public void Interact(PlayerModel playerModel)
        {
            playerModel.RocketModel.TakeDamage(MeteorModel.Damage);
        }
    }
}