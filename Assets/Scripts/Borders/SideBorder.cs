using Rocket.Components.Player;
using UnityEngine;

namespace Borders
{
    public class SideBorder : MonoBehaviour
    {
        [SerializeField] GameObject _otherBorder;
        [SerializeField] private float _offset;

        private BoxCollider _ownBoxCollider;
        private BoxCollider _otherBoxCollider;

        private void Start()
        {
            _ownBoxCollider = GetComponent<BoxCollider>();
            _otherBoxCollider = _otherBorder.GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.GetComponent<PlayerMovementStrategy>())
            {
                //todo: убрать условие, всегда добавлять оффсет, в самих объектах выставить разные в зависимости от стороны
                if (gameObject.name == "RightBorder")
                {
                    collision.transform.position = new Vector2(_otherBorder.transform.position.x + _offset,
                        collision.transform.position.y);
                }

                if (gameObject.name == "LeftBorder")
                {
                    collision.transform.position = new Vector2(_otherBorder.transform.position.x - _offset,
                        collision.transform.position.y);
                }
            }
        }
    }
}