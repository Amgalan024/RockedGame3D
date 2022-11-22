using UnityEngine;

namespace Rocket.Models
{
    public class EnemyModel
    {
        public int Reward { get; }
        public RocketModel RocketModel { get; }
        public Transform Target { get; set; }

        public EnemyModel(int reward, RocketModel rocketModel, Transform target)
        {
            Reward = reward;
            RocketModel = rocketModel;
            Target = target;
        }
    }
}