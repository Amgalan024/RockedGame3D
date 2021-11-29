using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MultiShotAttack : MonoBehaviour, IRocketAttack
{
    [SerializeField] private RocketGun[] rocketGunArray;
    public void Attack()
    {
        for (int i = 0; i < rocketGunArray.Length; i++)
        {
            rocketGunArray[i].ShootProjectile();
        }
    }
    public void Attack(Quaternion rotation)
    {
        for (int i = 0; i < rocketGunArray.Length; i++)
        {
            rocketGunArray[i].ShootProjectile(Quaternion.Euler(rotation.x, rotation.y, rotation.z + rocketGunArray[i].transform.rotation.eulerAngles.z));
        }
    }
}
