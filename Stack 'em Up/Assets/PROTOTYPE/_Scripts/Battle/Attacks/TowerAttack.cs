using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : IAttack {

    public int damage;

    public TowerAttack(IEnumerable<ComboAttack> components)
    {

    }

    public int GetDamage()
    {
        return damage;
    }

    public string GetName()
    {
        return "Combination";
    }

    public bool IsCombo()
    {
        return true;
    }
}
