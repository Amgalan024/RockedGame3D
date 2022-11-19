namespace Rocket.Models
{
    public class EnemyModel
    {
        public int Reward { get; }
        public RocketModel RocketModel { get; }

        public EnemyModel(int reward, RocketModel rocketModel)
        {
            Reward = reward;
            RocketModel = rocketModel;
        }
    }
}