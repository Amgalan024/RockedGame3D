using Core;
using Meteor.Models;
using UnityEngine;

namespace Meteor
{
    public class MeteorInitializer : MonoBehaviour
    {
        [SerializeField] private int _healthPoints;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private int _reward;

        public MeteorModel MeteorModel { set; get; }

        private void Awake()
        {
            InitializeMeteor();
        }

        public void InitializeMeteor()
        {
            MeteorModel = new MeteorModel(_healthPoints, _damage, _speed, _reward);

            foreach (var component in GetComponents<IGameEntityComponent<MeteorModel>>())
            {
                component.InitializeComponent(MeteorModel);
            }

            foreach (var component in GetComponentsInChildren<IGameEntityComponent<MeteorModel>>())
            {
                component.InitializeComponent(MeteorModel);
            }
        }
    }
}