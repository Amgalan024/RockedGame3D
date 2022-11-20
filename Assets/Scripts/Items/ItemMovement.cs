using UnityEngine;

namespace Items
{
    public class ItemMovement : MonoBehaviour
    {
        [SerializeField] private float _fallSpeed;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = new Vector3(0, -_fallSpeed);
        }
    }
}