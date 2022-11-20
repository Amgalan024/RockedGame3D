using Borders;
using Items;
using Meteor.Components;
using Rocket.Components;
using Rocket.Components.Enemy;
using Rocket.Components.Player;

namespace Core
{
    public class InteractionVisitorBase : IInteractionVisitor
    {
        public virtual void Visit(MeteorInteractionHandler meteorInteractionHandler)
        {
        }

        public virtual void Visit(PlayerInteractionHandler playerInteractionHandler)
        {
        }

        public virtual void Visit(EnemyInteractionHandler enemyInteractionHandler)
        {
        }

        public virtual void Visit(ItemInteractionHandler itemInteractionHandler)
        {
        }

        public virtual void Visit(BottomBorderInteractionHandler bottomBorderInteractionHandler)
        {
        }

        public virtual void Visit(SideBorderInteractionHandler sideBorderInteractionHandler)
        {
        }

        public virtual void Visit(RocketProjectileInteractionHandler rocketProjectileInteractionHandler)
        {
        }
    }
}