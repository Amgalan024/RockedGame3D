using UnityEngine;

namespace Rocket.Components.AttackTypes
{
    public class MultiShotAttackStrategy : MonoBehaviour, IRocketAttackStrategy
    {
        [SerializeField] private RocketGun[] _rocketGuns;

        public void Attack()
        {
            for (int i = 0; i < _rocketGuns.Length; i++)
            {
                _rocketGuns[i].ShootProjectile();
            }
        }

        public void Attack(Quaternion rotation)
        {
            for (int i = 0; i < _rocketGuns.Length; i++)
            {
                _rocketGuns[i].ShootProjectile(Quaternion.Euler(rotation.x, rotation.y,
                    rotation.z + _rocketGuns[i].transform.rotation.eulerAngles.z));
            }
        }
    }
}