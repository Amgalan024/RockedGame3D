using Core;
using Rocket.Models;

namespace Rocket.Components.Enemy
{
    public interface IEnemyComponent :IGameEntityComponent<EnemyModel>
    {
        EnemyModel EnemyModel { get; set; }
    }
}