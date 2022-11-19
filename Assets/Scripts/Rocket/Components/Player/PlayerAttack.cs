using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerAttack : MonoBehaviour, IRocketComponent
    {
        private IRocketAttackStrategy _rocketAttackStrategy;
        public RocketModel RocketModel { get; set; }

        private void Awake()
        {
            _rocketAttackStrategy = GetComponentInChildren<IRocketAttackStrategy>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _rocketAttackStrategy.Attack();
            }
        }

        public void Attack()
        {
            _rocketAttackStrategy.Attack();
        }

        public void InitializeComponent(RocketModel rocketModel)
        {
            this.RocketModel = rocketModel;
        }
    }
}