using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RocketRestoreStatsBuff : BuffItem
{
    [SerializeField] private int restoreHealthPoints;
    [SerializeField] private int restoreEnergyPoints;
    public override IEnumerator Buff(Rocket rocket)
    {
        rocket.RestoreHP(restoreHealthPoints);
        rocket.RestoreEP(restoreEnergyPoints);
        yield return null;
    }
}
