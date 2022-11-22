using Meteor.Models;
using UnityEngine;

namespace Meteor.Components
{
    public class MeteorAnimator : MonoBehaviour, IMeteorComponent
    {
        public MeteorModel MeteorModel { get; set; }

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

        public void InitializeComponent(MeteorModel meteorModel)
        {
            MeteorModel = meteorModel;
            MeteorModel.OnMeteorDestroyed += OnMeteorDestroyed;
        }

        private void OnMeteorDestroyed(bool byPlayer)
        {
            _animator.SetBool("IsDestroyed", true);
        }

        public void PlayExplodeAnim()
        {
            for (int i = 0; i < _explosionParticleSystems.Length; i++)
            {
                _explosionParticleSystems[i].Play();
            }
        }

        public void SetActiveFalse()
        {
            gameObject.SetActive(false);
        }
    }
}