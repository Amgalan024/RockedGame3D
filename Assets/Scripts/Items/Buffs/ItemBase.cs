using Cysharp.Threading.Tasks;
using Rocket.Models;
using UnityEngine;

namespace Items
{
    public abstract class ItemBase : MonoBehaviour
    {
        public abstract UniTask Buff(RocketModel rocketModel);
    }
}