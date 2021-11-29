using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DamageMultiplierBuff : PlayerBuff
{
    [SerializeField] private float duration;
    [SerializeField] private int multiplier;

    public override IEnumerator Buff(Rocket rocket)
    {
        rocket.MultiplyDamage(multiplier);
        yield return new WaitForSeconds(duration);
        rocket.DivideDamage(multiplier);
    }
}
