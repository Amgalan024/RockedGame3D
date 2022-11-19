using Rocket.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Rocket.Components.Player
{
    public class PlayerStatsPanel : MonoBehaviour, IPlayerComponent
    {
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Slider _energyBar;
        [SerializeField] private Text _damageText;
        [SerializeField] private Text _speedText;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _ammoText;

        public PlayerModel PlayerModel { get; set; }
        private RocketModel RocketModel { get; set; }

        public void InitializeComponent(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
            RocketModel = playerModel.RocketModel;

            SetSliderValue(_healthBar, RocketModel.HealthPoint);
            SetSliderValue(_energyBar, RocketModel.EnergyPoint);
            _damageText.text = $"Damage: {RocketModel.Damage}";
            _speedText.text = $"Speed: {RocketModel.Speed}";
            _scoreText.text = $"Score: {PlayerModel.PlayerScore}";
            _ammoText.text = $"Ammo: {RocketModel.Ammo}";
            RocketModel.OnHealthPointsChanged += OnHealthPointsChanged;
            RocketModel.OnEnergyPointsChanged += OnEnergyPointsChanged;
            RocketModel.OnDamageChanged += OnDamageChanged;
            RocketModel.OnSpeedChanged += OnSpeedChanged;
            PlayerModel.OnPlayerScoreChanged += OnPlayerScoreChanged;
            RocketModel.OnAmmoChanged += OnAmmoChanged;
            RocketModel.OnRocketDestroyed += OnPlayerDied;
        }

        private void OnPlayerDied(bool byPlayer)
        {
            RocketModel.OnHealthPointsChanged -= OnHealthPointsChanged;
            RocketModel.OnEnergyPointsChanged -= OnEnergyPointsChanged;
            RocketModel.OnDamageChanged -= OnDamageChanged;
            RocketModel.OnSpeedChanged -= OnSpeedChanged;
            PlayerModel.OnPlayerScoreChanged -= OnPlayerScoreChanged;
            RocketModel.OnRocketDestroyed -= OnPlayerDied;
        }

        private void OnHealthPointsChanged(int healthPoints)
        {
            _healthBar.value = healthPoints;
        }

        private void OnEnergyPointsChanged(int energyPoints)
        {
            _energyBar.value = energyPoints;
        }

        private void OnAmmoChanged(int ammo)
        {
            _ammoText.text = $"Ammo: {ammo}";
        }

        private void OnPlayerScoreChanged(int score)
        {
            _scoreText.text = $"Score: {score}";
        }

        private void OnDamageChanged(int damage)
        {
            _damageText.text = $"Damage: {damage}";
        }

        private void OnSpeedChanged(float speed)
        {
            _speedText.text = $"Speed: {speed}";
        }

        private void SetSliderValue(Slider slider, float max)
        {
            slider.maxValue = max;
            slider.minValue = 0;
            slider.value = max;
        }
    }
}