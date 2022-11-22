using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Projectile
{
    public class ProjectileInitializer : MonoBehaviour
    {
        public void InitializeProjectile(RocketModel rocketModel)
        {
            foreach (var rocketComponent in GetComponents<IRocketComponent>())
            {
                rocketComponent.InitializeComponent(rocketModel);
            }
        }
    }
}