using System;
using Cysharp.Threading.Tasks;
using Rocket.Models;
using UnityEngine;

namespace Items
{
    public class DamageMultiplierItem : ItemBase
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _damageMultiplier;
        [SerializeField] private int _ammoAmount;

        public override async UniTask Buff(RocketModel rocketModel)
        {
            rocketModel.AddAmmo(_ammoAmount);
            rocketModel.MultiplyDamage(_damageMultiplier);

            await UniTask.Delay(TimeSpan.FromSeconds(_duration));

            rocketModel.DivideDamage(_damageMultiplier);
        }
    }
}