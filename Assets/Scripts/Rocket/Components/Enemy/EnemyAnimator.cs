using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyAnimator : MonoBehaviour, IRocketComponent
    {
        public RocketModel RocketModel { get; set; }

        private Animator _animator;
        private ParticleSystem[] _explosionParticleSystems;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _explosionParticleSystems = GetComponentsInChildren<ParticleSystem>();
        }

        private void OnEnable()
        {
            _animator.SetBool("IsDestroyed", false);
        }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
            RocketModel.OnRocketDestroyed += OnEnemyDied;
        }

        #region AnimatorEvents

        public void SetActiveFalse()
        {
            gameObject.SetActive(false);
        }

        public void PlayExplodeAnim()
        {
            foreach (var particles in _explosionParticleSystems)
            {
                particles.Play();
            }
        }

        #endregion

        private void OnEnemyDied(bool byPlayer)
        {
            _animator.SetBool("IsDestroyed", true);
        }
    }
}