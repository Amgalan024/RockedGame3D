using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatsPanel : MonoBehaviour, IRocket, IGameObjectComponent<Rocket>
{
    [SerializeField] private Slider healthBar;
    public Rocket Rocket { get; set; }
    public void InitializeComponent(Rocket rocket)
    {
        this.Rocket = rocket;
        SetSliderValue(healthBar, Rocket.HealthPoint);
        rocket.OnHealthPointsChanged += OnHealthPointsChanged;
    }
    private void OnHealthPointsChanged(int healthPoints)
    {
        healthBar.value = healthPoints;
    }
    private void SetSliderValue(Slider Slider, float Max)
    {
        Slider.maxValue = Max;
        Slider.minValue = 0;
        Slider.value = Max;
    }
}
