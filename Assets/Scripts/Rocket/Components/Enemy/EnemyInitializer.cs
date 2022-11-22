using Core;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyInitializer : RocketInitializer
    {
        [SerializeField] private int _reward;

        public EnemyModel EnemyModel { private set; get; }

        public void InitializeEnemy(Transform projectileContainer, Transform target)
        {
            InitializeRocket(projectileContainer);

            EnemyModel = new EnemyModel(_reward, RocketModel, target);

            foreach (var component in GetComponentsInChildren<IGameEntityComponent<EnemyModel>>())
            {
                component.InitializeComponent(EnemyModel);
            }
        }
    }
}