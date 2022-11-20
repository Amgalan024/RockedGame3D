using Core;
using Meteor.Components;
using Rocket.Components.Enemy;
using Rocket.Components.Player;
using UnityEngine;

namespace Rocket.Components.InteractionHandlers
{
    public class RocketCollisionEnterVisitor : InteractionVisitorBase
    {
        private readonly GameObject _projectileGameObject;

        public RocketCollisionEnterVisitor(GameObject projectileGameObject)
        {
            _projectileGameObject = projectileGameObject;
        }

        public override void Visit(MeteorInteractionHandler meteorInteractionHandler)
        {
            base.Visit(meteorInteractionHandler);
            _projectileGameObject.SetActive(false);
        }

        public override void Visit(PlayerInteractionHandler playerInteractionHandler)
        {
            base.Visit(playerInteractionHandler);
            _projectileGameObject.SetActive(false);
        }

        public override void Visit(EnemyInteractionHandler enemyInteractionHandler)
        {
            base.Visit(enemyInteractionHandler);
            _projectileGameObject.SetActive(false);
        }
    }
}