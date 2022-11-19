using UnityEngine;

namespace Rocket.Components.AttackTypes
{
    public class SingleShotAttackStrategy : MonoBehaviour, IRocketAttackStrategy
    {
        [SerializeField] private RocketGun _rocketGun;

        public void Attack()
        {
            _rocketGun.ShootProjectile();
        }

        public void Attack(Quaternion rotation)
        {
            _rocketGun.ShootProjectile(rotation);
        }
    }
}