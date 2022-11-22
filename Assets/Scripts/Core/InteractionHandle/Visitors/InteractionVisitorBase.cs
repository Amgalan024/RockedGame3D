using Borders;
using Items;
using Meteor.Components;
using Rocket.Components.Enemy;
using Rocket.Components.Player;
using Rocket.Components.Projectile;

namespace Core.InteractionHandle.Visitors
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

        public virtual void Visit(ProjectileInteractionHandler projectileInteractionHandler)
        {
        }
    }
}