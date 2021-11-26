using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MeteorHealthPointsPanel : MonoBehaviour, IGameObjectComponent<Meteor>, IMeteor
{
    [SerializeField] private Slider healthBar;
    public Meteor Meteor { get; set; }
    public void InitializeComponent(Meteor meteor)
    {
        this.Meteor = meteor;
        SetSliderValue(healthBar, meteor.HealthPoints);
        meteor.OnHealthPointsChanged += OnHealthPointsChanged;
        meteor.OnMeteorDestroyed += OnMeteorDestroyed;
    }
    private void OnMeteorDestroyed()
    {
        Meteor.OnHealthPointsChanged -= OnHealthPointsChanged;
        Meteor.OnMeteorDestroyed -= OnMeteorDestroyed;
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