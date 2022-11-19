using System;

namespace Rocket.Models
{
    public class PlayerModel
    {
        public event Action<int> OnPlayerScoreChanged;

        public RocketModel RocketModel { get; }

        public int PlayerScore { private set; get; }

        public PlayerModel(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
        }

        public void AddScorePoints(int points)
        {
            PlayerScore += points;
            OnPlayerScoreChanged?.Invoke(PlayerScore);
        }

        public void SubtractScorePoints(int points)
        {
            PlayerScore -= points;
            OnPlayerScoreChanged?.Invoke(PlayerScore);
        }
    }
}