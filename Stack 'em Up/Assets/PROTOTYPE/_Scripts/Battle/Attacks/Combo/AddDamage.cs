using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamage : ComboAttack {

    public override void AddEffect(TowerAttack baseAttack)
    {
        baseAttack.damage += 3;
    }
}
