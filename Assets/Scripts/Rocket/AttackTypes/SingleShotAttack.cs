using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class SingleShotAttack : MonoBehaviour, IRocketAttack
{
    [SerializeField] private RocketGun rocketGun;
    public void Attack()
    {
        rocketGun.ShootProjectile();
    }

    public void Attack(Quaternion rotation)
    {
        rocketGun.ShootProjectile(rotation);
    }
}
