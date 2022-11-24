using Borders;
using Items;
using Meteor.Components;
using Rocket.Components.Enemy;
using Rocket.Components.Player;
using Rocket.Components.Projectile;

namespace Core.InteractionHandle.Visitors
{
    public interface IInteractionVisitor
    {
        void Visit(MeteorInteractionHandler meteorInteractionHandler);

        void Visit(PlayerInteractionHandler playerInteractionHandler);

        void Visit(EnemyInteractionHandler enemyInteractionHandler);

        void Visit(ItemInteractionHandler itemInteractionHandler);

        void Visit(BottomBorderInteractionHandler bottomBorderInteractionHandler);

        void Visit(SideBorderInteractionHandler sideBorderInteractionHandler);

        void Visit(ProjectileInteractionHandler projectileInteractionHandler);
    }
}