using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyAttackHandler : MonoBehaviour, IRocketComponent
    {
        public RocketModel RocketModel { get; set; }
        public Transform PlayerRocketTransform { set; get; }

        private IRocketAttackStrategy _rocketAttackStrategy;
        private float _timer;
        private Quaternion _aimRotation;

        private void Awake()
        {
            _rocketAttackStrategy = GetComponentInChildren<IRocketAttackStrategy>();
        }

        private void FixedUpdate()
        {
            Attack();
        }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
        }

        private void Attack()
        {
            if (_timer <= 0)
            {
                AimAtPlayer();
                _rocketAttackStrategy.Attack(_aimRotation);
                _timer = RocketModel.AttackSpeed;
            }

            if (_timer >= 0)
            {
                _timer -= Time.fixedDeltaTime;
            }
        }

        private void AimAtPlayer()
        {
            var playerPosition = PlayerRocketTransform.position;
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