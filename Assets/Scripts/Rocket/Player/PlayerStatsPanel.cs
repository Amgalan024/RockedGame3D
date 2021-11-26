using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStatsPanel : MonoBehaviour, IRocket,IGameObjectComponent<Rocket>
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider energyBar;
    [SerializeField] private Text damageText;
    [SerializeField] private Text speedText;
    public Rocket Rocket { get; set; }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
        SetSliderValue(healthBar, rocket.HealthPoint);
        SetSliderValue(energyBar, rocket.EnergyPoint);
        damageText.text = rocket.Damage.ToString();
        speedText.text = rocket.Speed.ToString();
        rocket.OnHealthPointsChanged += OnHealthPointsChanged;
        rocket.OnEnergyPointsChanged += OnEnergyPointsChanged;
        rocket.OnDamageChanged += OnDamageChanged;
        rocket.OnSpeedChanged += OnSpeedChanged;
        rocket.OnRocketDestroyed += OnPlayerDied;
    }
    private void OnPlayerDied()
    {
        Rocket.OnHealthPointsChanged -= OnHealthPointsChanged;
        Rocket.OnEnergyPointsChanged -= OnEnergyPointsChanged;
        Rocket.OnDamageChanged -= OnDamageChanged;
        Rocket.OnSpeedChanged -= OnSpeedChanged;
        Rocket.OnRocketDestroyed -= OnPlayerDied;
    }
    private void OnHealthPointsChanged(int healthPoints)
    {
        healthBar.value = healthPoints;
    }
    private void OnEnergyPointsChanged(int energyPoints)
    {
        energyBar.value = energyPoints;
    }
    private void OnDamageChanged(int damage)
    {
        damageText.text = damage.ToString();
    }
    private void OnSpeedChanged(float speed)
    {
        speedText.text = speed.ToString();
    }
    private void SetSliderValue(Slider Slider, float Max)
    {
        Slider.maxValue = Max;
        Slider.minValue = 0;
        Slider.value = Max;
    }
}
