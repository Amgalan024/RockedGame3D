using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyAttackHandler : MonoBehaviour, IEnemyComponent
    {
        public EnemyModel EnemyModel { get; set; }

        private IRocketAttackStrategy _rocketAttackStrategy;
        private Quaternion _aimRotation;
        private float _timer;

        private void Awake()
        {
            _rocketAttackStrategy = GetComponentInChildren<IRocketAttackStrategy>();
        }

        private void FixedUpdate()
        {
            Attack();
        }

        public void InitializeComponent(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;
        }

        private void Attack()
        {
            if (_timer <= 0)
            {
                AimAtTarget();
                _rocketAttackStrategy.Attack(_aimRotation);
                _timer = EnemyModel.RocketModel.AttackSpeed;
            }

            if (_timer >= 0)
            {
                _timer -= Time.fixedDeltaTime;
            }
        }

        private void AimAtTarget()
        {
            var playerPosition = EnemyModel.Target.position;
            var enemyPosition = transform.position;

            float a = enemyPosition.y - playerPosition.y;
            float b = Vector2.Distance(enemyPosition, playerPosition);
            float angle = Mathf.Acos(a / b) * Mathf.Rad2Deg;

            if (enemyPosition.x > playerPosition.x)
            {
                _aimRotation = Quaternion.Euler(0, 0, -angle);
            }
            else
            {
                _aimRotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}