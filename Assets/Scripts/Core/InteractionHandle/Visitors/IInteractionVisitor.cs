using Borders;
using Items;
using Meteor.Components;
using Rocket.Components;
using Rocket.Components.Enemy;
using Rocket.Components.Player;

namespace Core
{
    public interface IInteractionVisitor
    {
        void Visit(MeteorInteractionHandler meteorInteractionHandler);

        void Visit(PlayerInteractionHandler playerInteractionHandler);

        void Visit(EnemyInteractionHandler enemyInteractionHandler);

        void Visit(ItemInteractionHandler itemInteractionHandler);

        void Visit(BottomBorderInteractionHandler bottomBorderInteractionHandler);

        void Visit(SideBorderInteractionHandler sideBorderInteractionHandler);

        void Visit(RocketProjectileInteractionHandler rocketProjectileInteractionHandler);
    }
}