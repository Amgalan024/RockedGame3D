using Borders;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyMovementStrategy : MonoBehaviour, IRocketMovementStrategy
    {
        [SerializeField] private bool _moveRight;
        [SerializeField] private float _chaseDistance;

        public RocketModel RocketModel { get; set; }
        public Transform PlayerRocketTransform { set; get; }

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

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.GetComponent<SideBorder>())
            {
                _moveRight = !_moveRight;
            }
        }

        public void Movement()
        {
            AimAtPlayer();

            if (Vector3.Distance(transform.position, PlayerRocketTransform.position) >= _chaseDistance)
            {
                _rigidbody.velocity = new Vector2(0, -RocketModel.Speed);
            }
            else
            {
                if (_moveRight)
                {
                    _rigidbody.velocity = new Vector2(RocketModel.Speed, 0);
                }
                else
                {
                    _rigidbody.velocity = new Vector2(-RocketModel.Speed, 0);
                }
            }
        }

        private void AimAtPlayer()
        {
            float a = transform.position.y - PlayerRocketTransform.position.y;
            float b = Vector2.Distance(transform.position, PlayerRocketTransform.position);
            float angle = Mathf.Acos(a / b) * Mathf.Rad2Deg;

            if (transform.position.x > PlayerRocketTransform.position.x)
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

        public void InitializeComponent(RocketModel component)
        {
        }
    }
}