using Rocket.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Rocket.Components.Enemy
{
    public class EnemyStatsPanel : MonoBehaviour, IRocketComponent
    {
        [SerializeField] private Slider _healthBar;
        public RocketModel RocketModel { get; set; }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
            SetSliderValue(_healthBar, RocketModel.HealthPoint);
            rocketModel.OnHealthPointsChanged += OnHealthPointsChanged;
        }

        private void OnHealthPointsChanged(int healthPoints)
        {
            _healthBar.value = healthPoints;
        }

        private void SetSliderValue(Slider slider, float max)
        {
            slider.maxValue = max;
            slider.minValue = 0;
            slider.value = max;
        }
    }
}