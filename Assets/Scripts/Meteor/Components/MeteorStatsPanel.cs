using Meteor.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Meteor.Components
{
    public class MeteorStatsPanel : MonoBehaviour, IMeteorComponent
    {
        [SerializeField] private Slider _healthBar;
        public MeteorModel MeteorModel { get; set; }

        public void InitializeComponent(MeteorModel meteorModel)
        {
            MeteorModel = meteorModel;
            SetSliderValue(_healthBar, meteorModel.HealthPoints);
            meteorModel.OnHealthPointsChanged += OnHealthPointsChanged;
            meteorModel.OnMeteorDestroyed += OnMeteorDestroyed;
        }

        private void OnMeteorDestroyed(bool byPlayer)
        {
            MeteorModel.OnHealthPointsChanged -= OnHealthPointsChanged;
            MeteorModel.OnMeteorDestroyed -= OnMeteorDestroyed;
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