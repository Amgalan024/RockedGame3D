using Cysharp.Threading.Tasks;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyAnimator : MonoBehaviour, IRocketComponent
    {
        [SerializeField] private RocketExplosion _rocketExplosion;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        public RocketModel RocketModel { get; set; }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
            RocketModel.OnRocketDestroyed += OnEnemyDied;
        }

        private void OnEnemyDied(bool byPlayer)
        {
            PlayExplodeAnim();
        }

        private void PlayExplodeAnim()
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;

            _rocketExplosion.ExplodeAnimationAsync().ContinueWith(() =>
            {
                _rigidbody.isKinematic = false;
                _collider.enabled = true;
                gameObject.SetActive(false);
            });
        }
    }
}