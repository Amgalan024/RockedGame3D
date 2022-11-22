using Core;
using Rocket.Models;
using UnityEngine;

namespace Rocket
{
    public class RocketInitializer : MonoBehaviour
    {
        [SerializeField] private int _healthPoints;
        [SerializeField] private int _energyPoints;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private int _startAmmo;

        public RocketModel RocketModel { private set; get; }

        public void InitializeRocket(Transform projectilesContainer)
        {
            RocketModel = new RocketModel(_healthPoints, _energyPoints, _damage, _speed, _projectileSpeed, _attackSpeed,
                _startAmmo, transform, projectilesContainer);

            foreach (var component in GetComponentsInChildren<IGameEntityComponent<RocketModel>>())
            {
                component.InitializeComponent(RocketModel);
            }
        }
    }
}