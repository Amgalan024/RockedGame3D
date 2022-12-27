using UnityEngine;

namespace Rocket.Components
{
    public class RocketExplosionPart : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _distance;
        [SerializeField, Range(0, 1f)] private float _directionRange;

        public Vector3 GetMoveToPoint()
        {
            var position = transform.position;

            var randomDirection = _direction.normalized + new Vector3(Random.Range(-_directionRange, _directionRange),
                Random.Range(-_directionRange, _directionRange), Random.Range(-_directionRange, _directionRange));

            var direction = (position + randomDirection.normalized * _distance);

            return direction;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;

            Gizmos.DrawLine(position, (position + _direction.normalized * _distance));

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(position, GetMoveToPoint());
        }
    }
}