using UnityEngine;

namespace Rocket.Components
{
    public interface IRocketAttackStrategy
    {
        void Attack();
        void Attack(Quaternion rotation);
    }
}