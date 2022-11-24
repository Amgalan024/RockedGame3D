using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyMovementStrategy : MonoBehaviour, IRocketMovementStrategy, IEnemyComponent
    {
        [SerializeField] private float _chaseDistance;

        public EnemyModel EnemyModel { get; set; }

        private int _sideDirection = 1;
        private Rigidbody _rigidbody;
        private Quaternion _aimRotation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        public void InitializeComponent(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;
        }

        public void ChangeSideDirection()
        {
            _sideDirection *= -1;
        }

        public void Movement()
        {
            AimAtTarget();

            if (Mathf.Abs(transform.position.y - EnemyModel.Target.position.y) >= _chaseDistance)
            {
                _rigidbody.velocity = new Vector2(0, -EnemyModel.RocketModel.Speed);
            }
            else
            {
                _rigidbody.velocity = new Vector2(EnemyModel.RocketModel.Speed * _sideDirection, 0);
            }
        }

        private void AimAtTarget()
        {
            float a = transform.position.y - EnemyModel.Target.position.y;
            float b = Vector2.Distance(transform.position, EnemyModel.Target.position);
            float angle = Mathf.Acos(a / b) * Mathf.Rad2Deg;

            if (transform.position.x > EnemyModel.Target.position.x)
            {
                _aimRotation = Quaternion.Euler(0, 0, -angle);
            }
            else
            {
                _aimRotation = Quaternion.Euler(0, 0, angle);
            }

            transform.rotation = _aimRotation;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            var position = transform.position;

            Gizmos.DrawLine(position, new Vector3(position.x, position.y - _chaseDistance));
        }
    }
}