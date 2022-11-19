using UnityEngine;

namespace Utils
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _parallaxEffect;

        private float _lenght;
        private float _startPos;

        private void Start()
        {
            _startPos = transform.position.y;
            _lenght = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        private void FixedUpdate()
        {
            float temp = _camera.transform.position.y * (1 - _parallaxEffect);

            float distance = _camera.transform.position.y * _parallaxEffect;

            transform.position = new Vector3(transform.position.x, _startPos + distance, transform.position.z);

            if (temp >= _startPos + _lenght)
            {
                _startPos += _lenght * 2;
            }
            else if (temp <= _startPos - _lenght)
            {
                _startPos -= _lenght * 2;
            }
        }
    }
}