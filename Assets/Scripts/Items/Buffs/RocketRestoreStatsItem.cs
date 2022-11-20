using Cysharp.Threading.Tasks;
using Rocket.Models;
using UnityEngine;

namespace Items
{
    public class RocketRestoreStatsItem : ItemBase
    {
        [SerializeField] private int _restoreHealthPoints;
        [SerializeField] private int _restoreEnergyPoints;

        public override UniTask Buff(RocketModel rocketModel)
        {
            rocketModel.RestoreHP(_restoreHealthPoints);
            rocketModel.RestoreEP(_restoreEnergyPoints);
            return UniTask.CompletedTask;
        }
    }
}